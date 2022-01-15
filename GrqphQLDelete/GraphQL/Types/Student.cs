using System;

namespace GrqphQLDelete.GraphQL.Types
{
    public class Student
    {
        public int Id { get; set; }
        
        public string StudentName { get; set; }
        
        public string Surname { get; set; }

        public int Dormitory { get; set; }

        public int Faculty { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string BenefitCategory { get; set; }
    }
}