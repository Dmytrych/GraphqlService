namespace GrqphQLDelete.GraphQL.Types
{
    public class Dormitory
    {
        public int Id { get; set; }
        
        public string Number { get; set; }
        
        public int? CreationYear { get; set; }

        public string Address { get; set; }
        
        public int? Cost { get; set; }
        
        public string Description { get; set; }
    }
}