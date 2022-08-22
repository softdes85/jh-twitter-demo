using JH.TwitterDemo.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services
{
    public class TwitterConsumerService : ITwitterConsumerService
    {
        private readonly ITwittClient _twittClient;
        private readonly ITwitterQueueManager _queue;

        public TwitterConsumerService(ITwittClient twittClient,ITwitterQueueManager queue)
        {
            this._twittClient = twittClient;
            this._queue = queue;
        }
        public async Task ConsumeAsync(CancellationToken cancellationToken)
        {
            await foreach (var twitt in this._twittClient.GetTwittsAsync(cancellationToken))
            {
                _queue.EnqueueTwitt(twitt);
            }
        }
    }
}
