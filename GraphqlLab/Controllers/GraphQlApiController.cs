using GraphQL.SystemTextJson;
using GraphqlLab.Models;
using GrqphQLDelete;
using GrqphQLDelete.GraphQL;
using Microsoft.AspNetCore.Mvc;
using Ninject;

namespace GraphqlLab.Controllers
{
    [Route("[controller]")]
    public class GraphQlApiController : Controller
    {
        private static IReadOnlyKernel kernel =
            new KernelConfiguration(new GraphQlNinjectModule()).BuildReadonlyKernel();

        [HttpPost]
        [Route("getall")]
        public IActionResult Execute([FromBody] GraphQlRequest request)
        {
            var schema = new StudentsSchema(kernel);

            var res = schema.ExecuteAsync(x =>
            {
                //x.Query = "{ student( id: 1 ) { id dormitory { address } } }";
                x.Query = request.Query;
                x.OperationName = request.OperationName;
                x.Inputs = request.Variables.ToInputs();
            }).Result;

            return Ok(res);
        }
    }
}