using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private async Task ProcessTwittItemAsync(TwittInfo twitterItem)
        {
            await this._service.AddTwittAsync(twitterItem);
        }

        public async Task ProcessTwittsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // instead of the try catch inside the while this code needs to be updated to use Polly
                try
                {
                    if (this._queue.Count() == 0)
                    {
                        await Task.Delay(500, cancellationToken);
                        continue;
                    }
                    var twitt = _queue.DeQueueTwitt();
                    if (twitt != null)
                        await this.ProcessTwittItemAsync(twitt);
                }catch (Exception ex)
                {
                    this._logger.LogError(ex, "Error Processing the Twitts Queue");
                }
            }
        }
    }
}
