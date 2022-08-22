using JH.TwitterDemo.Data.Repositories.Interfaces;
using JH.TwitterDemo.Service.Models.Report;
using JH.TwitterDemo.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IHashTagRepository _hashTagRepository;
        private readonly ITwittRepository _twittRepository;

        public ReportService(IHashTagRepository hasTagRepository, ITwittRepository twittRepository)
        {
            this._hashTagRepository = hasTagRepository;
            this._twittRepository = twittRepository;
        }

        /// <inheritdoc/>
        public async Task<HashTagReport> HashTagReport(int topN)
        {
            var result = new HashTagReport();
            result.TotalTwitts = await this._twittRepository.TotalCount();
            var hasTags = await this._hashTagRepository.TopNAsync(topN);
            result.HashTags = hasTags.Select(c => new HashTagRecord()
            {
                Tag = c.Tag,
                NumberOfReferences = c.Count
            });
            return result;
        }
    }
}