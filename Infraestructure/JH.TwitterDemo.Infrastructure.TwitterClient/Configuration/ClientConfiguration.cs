using System;
using System.Collections.Generic;
using System.Text;

namespace JH.TwitterDemo.Infrastructure.TwitterClient.Configuration
{
    public class ClientConfiguration
    {
        public string StreamUrl { get; set; }
        public string OAuthUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string Token { get; set; }
    }
}
