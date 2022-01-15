using System.Threading.Tasks;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete
{
    public interface IDormitoryDataProvider
    {
        public Task<Dormitory> GetDormitoryById(int dormitoryId);
        
        public Task<Faculty> GetFacultyById(int facultyId);

        public Task<Student> GetStudentById(int studentId);
    }
}