using Microsoft.Extensions.DependencyInjection;

namespace JH.TwitterDemo.Data.Configuration
{
    public static class DataConfig
    {
        public static IServiceCollection ConfigureData(this IServiceCollection services)
        {
            return services;
        }
    }
}