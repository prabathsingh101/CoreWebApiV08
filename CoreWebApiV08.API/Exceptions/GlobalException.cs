﻿using CoreWebApiV08.API.Models.DTO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreWebApiV08.API.Exceptions
{
   
    public class GlobalException : IExceptionHandler
    {
        private readonly ILogger<GlobalException> _logger;

        public GlobalException(ILogger<GlobalException> logger)
        {
            this._logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
            CancellationToken cancellationToken)
        {

            _logger.LogError(exception, "An unexpected error occurred");

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type=exception.GetType().Name,
                Title = "An unexpected error occurred",
                Detail=exception.Message,
                Instance= $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });
            return true;  
        }
    }
    
}
