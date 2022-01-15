using GraphQL.Types;

namespace GrqphQLDelete.GraphQL.Types
{
    public class FacultyType : ObjectGraphType<Faculty>
    {
        public FacultyType()
        {
            Name = "FacultyType";

            Field(h => h.Id).Description("The id of the faculty.");
            Field(h => h.FacultyName, nullable: true).Description("Name of the faculty.");

            Interface<FacultyInterface>();
        }
    }
    
    public class FacultyInterface : InterfaceGraphType<Faculty>
    {
        public FacultyInterface()
        {
            Name = "FacultyInterface";

            Field(h => h.Id).Description("The id of the faculty.");
            Field(h => h.FacultyName, nullable: true).Description("Name of the faculty.");
        }
    }
}