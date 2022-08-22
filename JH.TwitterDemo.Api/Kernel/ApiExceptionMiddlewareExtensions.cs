using Microsoft.AspNetCore.Builder;

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