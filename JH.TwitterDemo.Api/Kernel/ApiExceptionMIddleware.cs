using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Api.Kernel
{
    public class ApiExceptionMIddleware
    {
        private readonly RequestDelegate next;
        private ILogger<ApiExceptionMIddleware> _logger;

        public ApiExceptionMIddleware(ILogger<ApiExceptionMIddleware> logger)
        {
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception in the middleware");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Unexpected Error");
            }
        }
    }
}