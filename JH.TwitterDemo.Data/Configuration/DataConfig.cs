using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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
