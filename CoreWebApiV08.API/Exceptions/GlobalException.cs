using CoreWebApiV08.API.Models.DTO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace CoreWebApiV08.API.Exceptions
{
   
    public class GlobalException : IExceptionHandler
    {
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(ILogger<GlobalException> logger)
        {
            this._logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception,
            CancellationToken cancellationToken)
        {

            _logger.LogError(exception, exception.Message);

            var details = new ProblemDetails()
            {
                Detail = $"API Error {exception.Message}",
                Instance = "API",
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "API Error",
                Type = "Server Error"
            };

            var response = JsonSerializer.Serialize(details);

            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(response, cancellationToken);

            return true;
        }
       
    }
    
}
