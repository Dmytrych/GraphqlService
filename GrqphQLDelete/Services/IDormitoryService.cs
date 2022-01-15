using System.Collections.Generic;
using System.Threading.Tasks;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete.Services
{
    public interface IDormitoryService
    {
        Task<IReadOnlyCollection<Dormitory>> GetAllAsync();

        Task<Dormitory> GetAsync(int id);
        
        Task<Dormitory> Add(Dormitory dormitory);
        
        Task<Dormitory> Delete(int id);
        
        Task<Dormitory> UpdateNumber(int id, string number);
    }
}