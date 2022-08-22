using Microsoft.AspNetCore.Builder;
using System;

namespace JH.TwitterDemo.Api.Kernel
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {   
            return builder.UseMiddleware<ApiExceptionMIddleware>();
        }
    }
}
