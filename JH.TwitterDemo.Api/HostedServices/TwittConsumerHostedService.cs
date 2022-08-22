using JH.TwitterDemo.Infrastructure.TwitterClient.Services;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Api.HostedServices
{
    public class TwittConsumerHostedService : BackgroundService
    {
        private readonly ILogger<TwittConsumerHostedService> _logger;
        
        private readonly IServiceScopeFactory _scopeFactory;
        

        public TwittConsumerHostedService(ILogger<TwittConsumerHostedService> logger, IServiceScopeFactory scopeFactory)
        {
            this._logger = logger;
            this._scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Twitts Hosted Service running.");

            await DoWork(stoppingToken);
        }
        
        private async Task DoWork(CancellationToken stoppingToken)
        {
            try
            {
                var scope = this._scopeFactory.CreateScope();
                var service = scope.ServiceProvider.GetService<ITwitterConsumerService>();
                await service.ConsumeAsync(stoppingToken);
            }catch(Exception ex)
            {
                int i = 0;
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Consume Twitts Hosted Service  is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
