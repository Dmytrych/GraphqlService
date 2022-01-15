using System.Threading.Tasks;
using GrqphQLDelete.Domain;
using GrqphQLDelete.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GrqphQLDelete.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IDatabaseContext _dbContext;

        public StudentsService(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var a = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            return a;
        }
    }
}