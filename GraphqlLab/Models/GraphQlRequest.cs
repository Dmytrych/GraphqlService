using System.Text.Json;

namespace GraphqlLab.Models
{
    public class GraphQlRequest
    {
        public string Query { get; set; }
        
        public string OperationName { get; set; }
        
        public JsonElement Variables { get; set; }
    }
}