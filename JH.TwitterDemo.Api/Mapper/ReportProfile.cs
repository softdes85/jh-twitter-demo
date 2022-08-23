using AutoMapper;
using JH.TwitterDemo.Api.Models;
using JH.TwitterDemo.Service.Models.Report;

namespace JH.TwitterDemo.Api.Mapper
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<HashTagReport, HashTagReportVM>();
            CreateMap<HashTagRecord, HashTagRecordVM>();
        }
    }
}
