using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JH.TwitterDemo.Service.Services
{
    public class TwitterQueueManager : ITwitterQueueManager
    {
        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
        public int Count()
        {
            return queue.Count;
        }

        public TwittInfo DeQueueTwitt()
        {
            try
            {
                if (this.queue.TryDequeue(out string result))
                {
                    var options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    options.Converters.Add(new JsonStringEnumConverter());

                    var twitt = JsonSerializer.Deserialize<TwittInfo>(result, options);
                    return twitt;
                }
            }catch (Exception ex)
            {
                // need to log
            }
            return null;
        }

        public void EnqueueTwitt(string twitt)
        {
           this.queue.Enqueue(twitt);
        }
    }
}
