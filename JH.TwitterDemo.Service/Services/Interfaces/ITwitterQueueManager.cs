using JH.TwitterDemo.Service.Models.Twitter;
using System;
using System.Collections.Generic;
using System.Text;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwitterQueueManager
    {
        void EnqueueTwitt(string twitt);
        TwittInfo DeQueueTwitt();
        int Count();
    }
}
