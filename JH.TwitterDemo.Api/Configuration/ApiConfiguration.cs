using JH.TwitterDemo.Api.HostedServices;
using JH.TwitterDemo.Data.Context;
using JH.TwitterDemo.Data.Repositories;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using JH.TwitterDemo.Data.UnitOfWork;
using JH.TwitterDemo.Infrastructure.TwitterClient.Configuration;
using JH.TwitterDemo.Infrastructure.TwitterClient.Services;
using JH.TwitterDemo.Service.Services;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Api.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection SetApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly(), (typeof(TwittService).Assembly));

            // setting up db
            services.AddDbContext<TwitterDBContext>(opt => opt.UseInMemoryDatabase("TwitterDB"));

            // setting up configuration
            services.Configure<ClientConfiguration>(options => configuration.GetSection("ApiKeys").GetSection("Twitter").Bind(options));

            // registering hosted services
            services.AddHostedService<TwittProcessorHostedService>();
            services.AddHostedService<TwittConsumerHostedService>();

            // registering http clients
            services.AddHttpClient<ITwittClient, TwittClient>()
                .AddPolicyHandler(GetRetryPolicy());

            // registering services
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<TwitterDBContext>));
            services.AddSingleton<ITwitterQueueManager, TwitterQueueManager>();
            services.AddScoped<ITwittProcessingService, TwittProcessingService>();
            services.AddScoped<ITwitterConsumerService, TwitterConsumerService>();
            services.AddScoped<ITwittService, TwittService>();
            services.AddScoped<IReportService, ReportService>();

            // registering repositories
            services.AddScoped<ITwittRepository, TwittRepository>();
            services.AddScoped<IHashTagRepository, HashTagRepository>();
            services.AddScoped<IMentionRepository, MentionRepository>();

            return services;
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            var retryCount = 5;
            return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
               .WaitAndRetryAsync(
                    retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt))
                    );
        }
    }
}