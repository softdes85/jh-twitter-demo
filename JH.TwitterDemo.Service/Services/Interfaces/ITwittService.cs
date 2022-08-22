﻿using JH.TwitterDemo.Service.Models.Twitter;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface ITwittService
    {
        /// <summary>
        /// Add Twit Information to system of records
        /// </summary>
        /// <param name="twitt">The twitt info</param>
        /// <returns>Task</returns>
        Task AddTwittAsync(TwittInfo twitt);
    }
}