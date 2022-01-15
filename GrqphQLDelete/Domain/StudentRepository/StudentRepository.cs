using System.Collections.Generic;
using System.Linq;
using GrqphQLDelete.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GrqphQLDelete.Domain.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDatabaseContext _studentContext;
        
        public StudentRepository(
            IDatabaseContext studentContext)
        {
            _studentContext = studentContext;
        }

        public Student GetStudent(int studentId)
            => _studentContext.Students
                .Include(e => e.Dormitory)
                .Include(e => e.Faculty)
                .Include(e => e.BenefitCategory)
                .FirstOrDefault(student => studentId == student.Id);

        public IReadOnlyCollection<Student> GetAllStudents()
            => _studentContext.Students
                .Include(e => e.Dormitory)
                .Include(e => e.Faculty)
                .Include(e => e.BenefitCategory)
                .ToList();
    }
}