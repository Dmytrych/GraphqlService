using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using GrqphQLDelete.GraphQL.Types;

namespace GrqphQLDelete
{
    public class Query : ObjectGraphType<Query>
    {
        private static List<DormitoryType> Values { get; set; }

        public Query()
        {
            Values = new List<DormitoryType>
            {
                new DormitoryType
                {
                }
            };
            Field<ListGraphType<DormitoryType>>("dormitories");
        }
        
        public List<DormitoryType> GetDormitories()
        {
            return Values;
        }
    }
}