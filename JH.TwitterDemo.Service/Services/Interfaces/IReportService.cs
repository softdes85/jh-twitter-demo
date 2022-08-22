using JH.TwitterDemo.Service.Models.Report;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// Process HashTag data to provide Custom Report.
        /// </summary>
        /// <param name="topN">Top (N) hastags in the system.</param>
        /// <returns>The Hashtag Report</returns>
        public Task<HashTagReport> HashTagReport(int topN);
    }
}