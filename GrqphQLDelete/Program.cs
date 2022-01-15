using System;
using System.Threading.Tasks;
using GraphQL.SystemTextJson;
using GrqphQLDelete.GraphQL;
using Ninject;

namespace GrqphQLDelete
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var kernel = new KernelConfiguration(new GraphQlNinjectModule()).BuildReadonlyKernel();

            var schema = new StudentsSchema(kernel);

            var res = await schema.ExecuteAsync(x =>
            {
                //x.Query = "{ student( id: 1 ) { id dormitory { address } } }";
                x.Query = @"{
                    mutation($dormitory:DormitoryInputType){addDormitory(dormitory: !$dormitory ) { id number } }
                }";
            });
            
            Console.WriteLine(res);
        }
    }
}