// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using GrqphQLDelete.Domain;
// using GrqphQLDelete.Domain.StudentRepository;
// using GrqphQLDelete.GraphQL.Types;
//
// namespace GrqphQLDelete
// {
//     public class DormitoryDataProvider : IDormitoryDataProvider
//     {
//         private readonly IDatabaseContext studentRepository;
//         
//         private readonly List<Student> students = new List<Student>();
//
//         private readonly List<Faculty> faculties = new List<Faculty>();
//
//         public DormitoryDataProvider()
//         {
//
//             students.AddRange(new List<Student>
//             {
//                 new Student
//                 {
//                     Id = 1,
//                     StudentName = "Gondon"
//                 }
//             });
//             
//             faculties.AddRange(new List<Faculty>
//             {
//                 new Faculty
//                 {
//                     Id = 1,
//                     FacultyName = "Faculty name"
//                 }
//             });
//         }
//
//         public Task<Dormitory> GetDormitoryById(int dormitoryId)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public Task<Faculty> GetFacultyById(int facultyId)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public Task<Student> GetStudentById(int studentId)
//         {
//             return Task.FromResult(studentRepository.GetStudent(studentId));
//         }
//     }
// }