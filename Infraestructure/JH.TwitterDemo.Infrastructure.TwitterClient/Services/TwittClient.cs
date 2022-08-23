﻿using JH.TwitterDemo.Infrastructure.TwitterClient.Configuration;

using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;

namespace JH.TwitterDemo.Infrastructure.TwitterClient.Services
{
    public class TwittClient : ITwittClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ClientConfiguration> options;

        public TwittClient(HttpClient httpClient, IOptions<ClientConfiguration> options)
        {
            this._httpClient = httpClient;
            this.options = options;
        }

        public async IAsyncEnumerable<string> GetTwittsAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.Value.Token}");

            using var stream = await this._httpClient.GetStreamAsync($"{options.Value.StreamUrl}?tweet.fields=entities");
            using var streamReader = new StreamReader(stream);
            while (!streamReader.EndOfStream || cancellationToken.IsCancellationRequested)
            {
                yield return await streamReader.ReadLineAsync();
            }
        }
    }
}