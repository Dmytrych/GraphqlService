using GraphQL;
using GraphQL.Types;
using GrqphQLDelete.GraphQL.Types;
using GrqphQLDelete.Services;

namespace GrqphQLDelete.GraphQL.Mutation
{
    public class DormitoryMutation : ObjectGraphType
    {
        public DormitoryMutation(IDormitoryService dormitoryService)
        {
            Name = "DormitoryMutation";

            Field<DormitoryType>(
                "addDormitory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DormitoryInputType>> { Name = "dormitory" }
                ),
                resolve: context =>
                {
                    var dormitory = context.GetArgument<Dormitory>("dormitory");
                    return dormitoryService.Add(dormitory);
                });
            
            Field<DormitoryType>(
                "deleteDormitory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var dormitory = context.GetArgument<int>("id");
                    return dormitoryService.Delete(dormitory);
                });
            
            Field<DormitoryType>(
                "changeNumber",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "number" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var number = context.GetArgument<string>("number");

                    return dormitoryService.UpdateNumber(id, number);
                });
        }
    }
}