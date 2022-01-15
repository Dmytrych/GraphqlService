using GraphQL.Types;

namespace GrqphQLDelete.GraphQL.Types
{
    public class DormitoryType : ObjectGraphType<Dormitory>
    {
        public DormitoryType()
        {
            Name = "DormitoryType";

            Field(h => h.Id).Description("The id of the dormitory.");
            Field(h => h.Number, nullable: true).Description("Number of the dormitory.");
            Field(h => h.CreationYear, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Address, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Cost, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Description, nullable: true).Description("Number of the dormitory.");

            Interface<DormitoryInterface>();
        }
    }
    
    public class DormitoryInterface : InterfaceGraphType<Dormitory>
    {
        public DormitoryInterface()
        {
            Name = "DormitoryInterface";

            Field(d => d.Id).Description("The id of the character.");
            Field(h => h.Number, nullable: true).Description("Number of the dormitory.");
            Field(h => h.CreationYear, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Address, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Cost, nullable: true).Description("Number of the dormitory.");
            Field(h => h.Description, nullable: true).Description("Number of the dormitory.");
        }
    }
}