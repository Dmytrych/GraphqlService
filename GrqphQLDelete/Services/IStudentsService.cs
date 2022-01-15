using System.Threading.Tasks;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete.Services
{
    public interface IStudentsService
    {
        public Task<Student> GetStudentById(int id);
    }
}