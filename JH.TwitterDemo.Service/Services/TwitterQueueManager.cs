using JH.TwitterDemo.Service.Models.Twitter;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JH.TwitterDemo.Service.Services
{
    public class TwitterQueueManager : ITwitterQueueManager
    {
        public readonly ILogger<TwitterQueueManager> _logger;

        public TwitterQueueManager(ILogger<TwitterQueueManager> logger)
        {
            this._logger = logger;
        }

        private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

        /// <inheritdoc/>
        public int Count()
        {
            return queue.Count;
        }

        /// <inheritdoc/>
        public TwittInfo DeQueueTwitt()
        {
            if (this.queue.TryDequeue(out string result))
            {
                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                options.Converters.Add(new JsonStringEnumConverter());

                var setting = new JsonSerializerSettings()
                {
                    Error = (se, ev) =>
                    {
                        ev.ErrorContext.Handled = true;
                        this._logger.LogError(ev.ErrorContext.Error.Message);
                    },
                    ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    }
                };
                var twitt = JsonConvert.DeserializeObject<TwittInfo>(result, setting);
                return twitt;
            }

            return null;
        }

        /// <inheritdoc/>
        public void EnqueueTwitt(string twitt)
        {
            this.queue.Enqueue(twitt);
        }
    }
}