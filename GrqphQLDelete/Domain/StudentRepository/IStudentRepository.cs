using System.Collections.Generic;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete.Domain.StudentRepository
{
    public interface IStudentRepository
    {
        Student GetStudent(int studentId);
        
        IReadOnlyCollection<Student> GetAllStudents();
    }
}