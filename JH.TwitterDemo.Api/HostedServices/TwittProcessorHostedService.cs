using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Api.HostedServices
{
    public class TwittProcessorHostedService : BackgroundService
    {        
        private readonly ILogger<TwittProcessorHostedService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;                

        public TwittProcessorHostedService(
            ILogger<TwittProcessorHostedService> logger,
            IServiceScopeFactory scopeFactory)
        {
            this._logger = logger;
            this._scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Processing Twtitts Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            var scope = this._scopeFactory.CreateScope();
            var processingService = scope.ServiceProvider.GetService<ITwittProcessingService>();
            await processingService.ProcessTwittsAsync(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Processing Twtitts Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}