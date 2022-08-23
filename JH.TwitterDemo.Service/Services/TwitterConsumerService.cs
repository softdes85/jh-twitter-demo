using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Polly.Timeout;
using System;
using System.Net.Http;
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
            await foreach (var twitt in this._twittClient.GetTwittsAsync(cancellationToken).WithCancellation(cancellationToken))
            {
                _queue.EnqueueTwitt(twitt);
            }
        }
    }
}