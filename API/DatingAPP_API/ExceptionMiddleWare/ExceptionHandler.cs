using System.Net;
using System.Text.Json;
using DatingAPP_API.DTO;

namespace DatingAPP_API.ExceptionMiddleWare
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger<APIException> _logger;

        public ExceptionHandler(RequestDelegate next,IHostEnvironment env ,ILogger<APIException> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try {
                await _next(context);
            }
            catch(Exception ex) {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()? new APIException(context.Response.StatusCode,ex.Message,ex.StackTrace?.ToString())
                    : new APIException(context.Response.StatusCode, "Internal server Error");
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            }
        }
    }
}
