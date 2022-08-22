using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services
{
    public class TwittProcessingService : ITwittProcessingService
    {
        private readonly ITwitterQueueManager _queue;
        private readonly ITwittService _service;
        private readonly ILogger _logger;

        public TwittProcessingService(ILogger<TwittProcessingService> logger, ITwitterQueueManager queue, ITwittService twittService)
        {
            this._queue = queue;
            this._service = twittService;
            this._logger = logger;
        }

        /// <inheritdoc/>
        public async Task ProcessTwittsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (this._queue.Count() == 0)
                    {
                        await Task.Delay(500, cancellationToken);
                        continue;
                    }
                    var twitt = _queue.DeQueueTwitt();
                    if (twitt != null)
                        await this._service.AddTwittAsync(twitt);
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Error Processing the Twitts Queue");
                }
            }
        }
    }
}