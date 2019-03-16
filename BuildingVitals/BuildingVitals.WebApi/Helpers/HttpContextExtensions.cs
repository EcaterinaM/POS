using System.Text;
using System.Threading.Tasks;
using BuildingVitals.BusinessContracts.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BuildingVitals.WebApi.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task<HttpContext> SetResponse(this HttpContext httpContext, int statusCode, string message)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = @"application/json";

            var response = new ExceptionModel(message);

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonResponse = JsonConvert.SerializeObject(response, serializerSettings);
            await httpContext.Response.WriteAsync(jsonResponse, Encoding.UTF8);

            return httpContext;
        }
    }
}
