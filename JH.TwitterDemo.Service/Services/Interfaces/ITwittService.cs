using JH.TwitterDemo.Service.Models.Twitter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwittService
    {
        Task AddTwittAsync(TwittInfo twitt);        
    }
}
