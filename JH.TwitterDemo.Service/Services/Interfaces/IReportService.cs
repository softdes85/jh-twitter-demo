using JH.TwitterDemo.Service.Models.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface IReportService
    {
        public Task<HashTagReport> HashTagReport(int topN);
    }
}
