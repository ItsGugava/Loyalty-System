using Loyalty_System.Interfaces;
using System.Net;

namespace Loyalty_System.CustomMiddleware
{
    public class ApiKeyMiddleware
    {
        private readonly IApiKeyValidation _apiKeyValidation;
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(IApiKeyValidation apiKeyValidation, RequestDelegate next)
        {
            _apiKeyValidation = apiKeyValidation;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userApiKey = context.Request.Headers["X-API-Key"];
            if((string.IsNullOrEmpty(userApiKey)) || !_apiKeyValidation.IsValidApiKey(userApiKey))
            {
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                return;
            }
            await _next(context);
        }
    }
}
