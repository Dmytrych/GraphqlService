using GraphQL.Types;
using GrqphQLDelete.Services;

namespace GrqphQLDelete.GraphQL.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType(IDormitoryService dormitoryService, IFacultyService facultyService)
        {
            Name = "StudentType";

            Field(h => h.Id).Description("The id of the student.");
            Field(h => h.StudentName, nullable: true).Description("Student name.");
            Field(h => h.Surname, nullable: true).Description("Student surname.");
            Field(h => h.BirthDate, nullable: true).Description("Student date of birth.");
            Field(h => h.BenefitCategory, nullable: true).Description("Student benefit category.");
            
            Field<DormitoryType>(
                "dormitory",
                resolve: context => dormitoryService.GetAsync(context.Source.Dormitory)
            );
            
            Field<FacultyType>(
                "faculty",
                resolve: context => facultyService.GetFacultyById(context.Source.Faculty)
            );

            Interface<StudentInterface>();
        }
    }
    
    public class StudentInterface : InterfaceGraphType<Student>
    {
        public StudentInterface()
        {
            Name = "StudentInterface";

            Field(h => h.Id).Description("The id of the student.");
            Field(h => h.StudentName, nullable: true).Description("Student name.");
            Field(h => h.Surname, nullable: true).Description("Student surname.");
            Field<DormitoryType>("dormitory", "Student dormitory.");
            Field<FacultyType>("faculty", "Student faculty.");
            Field(h => h.BirthDate, nullable: true).Description("Student date of birth.");
            Field(h => h.BenefitCategory, nullable: true).Description("Student benefit category.");
        }
    }
}