using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GrqphQLDelete.Domain;
using GrqphQLDelete.GraphQL.Types;
using Microsoft.Extensions.Caching.Memory;

namespace GrqphQLDelete.Services
{
    public class DormitoryService : IDormitoryService
    {
        private const int Timeout = 1000;
        private const string InfoUri = "http://localhost:5002/FacultyInfoApi/get-all";
        private const string CostsUri = "http://localhost:5004/FacultyDetailsApi/get-costs";
        private const string DetailsUri = "http://localhost:5004/FacultyDetailsApi/get-description";

        private readonly IDatabaseContext _dbContext;
        private readonly IMemoryCache _cache;

        private static bool infoWasCached = false;
        private static bool costsWasCached = false;

        public DormitoryService(IDatabaseContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }
        
        public async Task<Dormitory> GetAsync(int id)
        {
            var dormitory = _dbContext.Dormitories.FirstOrDefault(d => d.Id == id);

            if (dormitory == null)
            {
                return null;
            }
            
            var info = GetInfo(dormitory.Number);
            var cost = GetPrice(dormitory.Number);

            await Task.WhenAll(info, cost);
                
            var description = GetDescription(dormitory.Number);

            var dorm =  new Dormitory
            {
                Address = info.Result?.address,
                CreationYear = info.Result?.creationYear,
                Number = dormitory.Number,
                Id = dormitory.Id,
                Cost = cost.Result?.cost,
                Description = description.Result
            };

            return dorm;
        }

        public Task<Dormitory> Add(Dormitory dormitory)
        {
            var dorm = _dbContext.Dormitories.Add(dormitory);
            _dbContext.SaveChanges();
            return Task.FromResult(dorm.Entity);
        }

        public Task<Dormitory> Delete(int id)
        {
            var dorm = _dbContext.Dormitories.FirstOrDefault(x => x.Id == id);

            if (dorm != null)
            {
                _dbContext.Dormitories.Remove(dorm);
                _dbContext.SaveChanges();
            }

            return Task.FromResult(dorm);
        }

        public Task<Dormitory> UpdateNumber(int id, string number)
        {
            var dorm = _dbContext.Dormitories.FirstOrDefault(x => x.Id == id);

            if (dorm != null)
            {
                dorm.Number = number;
                _dbContext.SaveChanges();
            }

            return Task.FromResult(dorm);
        }

        public async Task<IReadOnlyCollection<Dormitory>> GetAllAsync()
        {
            var dormitories = _dbContext.Dormitories.ToList();

            var resultTasks = dormitories.Take(1000).Select(async d =>
            {
                var info = GetInfo(d.Number);
                var cost = GetPrice(d.Number);

                await Task.WhenAll(info, cost);
                
                var description = GetDescription(d.Number);

                return new Dormitory
                {
                    Address = info.Result?.address,
                    CreationYear = info.Result?.creationYear,
                    Number = d.Number,
                    Id = d.Id,
                    Cost = cost.Result?.cost,
                    Description = description.Result
                };
            });

            return await Task.WhenAll(resultTasks);
        }
        
        private async Task<DormitoryInfoModel> GetInfo(string dormNumber)
        {
            var cachedInfo = _cache.Get<DormitoryInfoModel>(dormNumber + "Inf");

            if (cachedInfo != null)
            {
                return cachedInfo;
            }
            
            if (infoWasCached)
            {
                return null;
            }

            var requestedInfo = await RequestInfoAsync<DormitoryInfoModel>(InfoUri);

            if (!requestedInfo.Any())
            {
                _cache.Get<DormitoryInfoModel>(dormNumber + "Inf");
            }

            foreach (var dormInfo in requestedInfo)
            {
                if (dormInfo.number != null && dormInfo.address != null)
                {
                    WriteToCache(dormInfo.number + "Inf", dormInfo);
                }
            }

            infoWasCached = true;

            return _cache.Get<DormitoryInfoModel>(dormNumber + "Inf");
        }

        private async Task<DormitoryСostsInfoModel> GetPrice(string dormNumber)
        {
            var cachedInfo = _cache.Get<DormitoryСostsInfoModel>(dormNumber + "Price");

            if (cachedInfo != null)
            {
                return cachedInfo;
            }
            
            if (costsWasCached)
            {
                return null;
            }

            var requestedInfo = await RequestInfoAsync<DormitoryСostsInfoModel>(CostsUri);

            if (!requestedInfo.Any())
            {
                _cache.Get<DormitoryСostsInfoModel>(dormNumber + "Price");
            }

            foreach (var dormInfo in requestedInfo)
            {
                if (dormInfo.number != null)
                {
                    WriteToCache(dormInfo.number + "Price", dormInfo);
                }
            }

            costsWasCached = true;

            return _cache.Get<DormitoryСostsInfoModel>(dormNumber + "Price");
        }

        private async Task<IReadOnlyCollection<T>> RequestInfoAsync<T>(string uri)
        {
            var req = WebRequest.CreateHttp(uri);
            req.Timeout = Timeout;
            var res = await req.GetResponseAsync();

            await using Stream stream = res.GetResponseStream();
            using StreamReader reader = new StreamReader(stream);

            try
            {
                var str = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<IReadOnlyCollection<T>>(str);
            }
            catch (JsonException)
            {
                Console.WriteLine("Data from url could not be reached: " + uri);
                return new List<T>();
            }
        }
        
        private IReadOnlyCollection<T> RequestInfo<T>(string uri)
        {
            var req = WebRequest.CreateHttp(uri);
            req.Timeout = Timeout;
            var res = req.GetResponse();

            using Stream stream = res.GetResponseStream();
            using StreamReader reader = new StreamReader(stream);

            try
            {
                var str = reader.ReadToEnd();
                return JsonSerializer.Deserialize<IReadOnlyCollection<T>>(str);
            }
            catch (JsonException)
            {
                Console.WriteLine("Data from url could not be reached: " + uri);
                return new List<T>();
            }
        }
        
        private async Task<string> GetDescription(string number)
        {
            var res = await WebRequest.CreateHttp(DetailsUri + "/" + number).GetResponseAsync();

            await using Stream stream = res.GetResponseStream();
            using StreamReader reader = new StreamReader(stream);

            try
            {
                return await reader.ReadToEndAsync();
            }
            catch (JsonException)
            {
                Console.WriteLine("Data from url could not be reached: " + DetailsUri);
                return String.Empty;
            }
        }

        private void WriteToCache<T>(string dormNumber, T obj)
        {
            _cache.Set(dormNumber, obj);
        }
    }
    
    public class DormitoryInfoModel
    {
        public int id { get; set; }
        
        public string number { get; set; }

        public int creationYear { get; set; }

        public string address { get; set; }
    }
    
    public class DormitoryСostsInfoModel
    {
        public string number { get; set; }
        
        public int cost { get; set; }
    }
}