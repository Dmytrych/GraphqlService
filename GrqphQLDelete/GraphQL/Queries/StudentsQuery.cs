using GraphQL;
using GraphQL.Types;
using GrqphQLDelete.GraphQL.Types;
using GrqphQLDelete.Services;

namespace GrqphQLDelete.GraphQL.Queries
{
    public class StudentsQuery : ObjectGraphType<object>
    {
        public StudentsQuery(
            IDormitoryService dormitoryService,
            IFacultyService facultyService,
            IStudentsService studentsService)
        {
            Name = "Query";

            Field<DormitoryType>(
                 "dormitory",
                 arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the dormitory" }
                 ),
                 resolve: context => dormitoryService.GetAsync(context.GetArgument<int>("id")));
            
            Field<FacultyType>(
                 "faculty",
                 arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the faculty" }
                 ),
                 resolve: context => facultyService.GetFacultyById(context.GetArgument<int>("id")));
            
            Field<StudentType>(
                "student",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "id of the student" }
                ),
                resolve: context => studentsService.GetStudentById(context.GetArgument<int>("id")));
        }
    }
}