using System.Threading.Tasks;
using GrqphQLDelete.Domain;
using GrqphQLDelete.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GrqphQLDelete.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IDatabaseContext _dbContext;
        
        public FacultyService(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Faculty> GetFacultyById(int id)
            => await _dbContext.Faculties.FirstOrDefaultAsync(f => f.Id == id);
    }
}