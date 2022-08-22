using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services.Interfaces;
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
        public TwittProcessingService(ITwitterQueueManager queue, ITwittService twittService)
        {
            this._queue = queue;
            this._service = twittService;
        }

        private async Task ProcessTwittItemAsync(TwittInfo twitterItem)
        {
            await this._service.AddTwittAsync(twitterItem);
        }

        public async Task ProcessTwittsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (this._queue.Count() == 0)
                {
                    await Task.Delay(500, cancellationToken);
                    continue;
                }
                var twitt = _queue.DeQueueTwitt();   
                if(twitt != null)
                    await  this.ProcessTwittItemAsync(twitt);
            }
        }
    }
}
