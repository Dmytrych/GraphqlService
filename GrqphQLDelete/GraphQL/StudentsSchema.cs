using System;
using GraphQL.Types;
using GrqphQLDelete.GraphQL.Mutation;
using GrqphQLDelete.GraphQL.Queries;

namespace GrqphQLDelete.GraphQL
{
    public class StudentsSchema : Schema
    {
        public StudentsSchema(IServiceProvider provider)
            : base(provider, false)
        {
            Query = (StudentsQuery) provider.GetService(typeof(StudentsQuery));
            Mutation = (DormitoryMutation) provider.GetService(typeof(DormitoryMutation));
        }
    }
}