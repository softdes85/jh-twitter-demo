using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services
{
    public class TwitterConsumerService : ITwitterConsumerService
    {
        private readonly ITwittClient _twittClient;
        private readonly ITwitterQueueManager _queue;
        private readonly ILogger _logger;

        public TwitterConsumerService(ILogger<TwitterConsumerService> logger, ITwittClient twittClient, ITwitterQueueManager queue)
        {
            this._twittClient = twittClient;
            this._queue = queue;
            this._logger = logger;
        }

        /// <inheritdoc/>
        public async Task ConsumeAsync(CancellationToken cancellationToken)
        {
            // TODO: instead of the try catch inside the while this code needs to be updated to use Polly

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await foreach (var twitt in this._twittClient.GetTwittsAsync(cancellationToken))
                    {
                        _queue.EnqueueTwitt(twitt);
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Error receiving Twitts From Stream");
                }
            }
        }
    }
}