using System.Threading.Tasks;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete.Services
{
    public interface IFacultyService
    {
        Task<Faculty> GetFacultyById(int id);
    }
}