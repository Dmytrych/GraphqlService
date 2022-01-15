using GrqphQLDelete.Domain;
using GrqphQLDelete.Services;
using Microsoft.Extensions.Caching.Memory;
using Ninject.Modules;

namespace GrqphQLDelete
{
    public class GraphQlNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFacultyService>().To<FacultyService>();
            Bind<IDormitoryService>().To<DormitoryService>();
            Bind<IStudentsService>().To<StudentsService>();
            
            Bind<IDatabaseContext>().ToConstant(new MsSqlDatabaseContext());
            Bind<IMemoryCache>().ToConstant(new MemoryCache(new MemoryCacheOptions
            {
                Clock = null
            }));
        }
    }
}