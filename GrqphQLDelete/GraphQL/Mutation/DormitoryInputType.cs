using GraphQL.Types;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete.GraphQL.Mutation
{
    public class DormitoryInputType : InputObjectGraphType<Dormitory>
    {
        public DormitoryInputType()
        {
            Name = "DormitoryInputType";
            Field(x => x.Number);
        }
    }
}