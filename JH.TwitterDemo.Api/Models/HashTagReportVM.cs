using System.Collections.Generic;

namespace JH.TwitterDemo.Api.Models
{
    public class HashTagReportVM
    {

        public int TotalTwitts { get; set; }
        public IEnumerable<HashTagRecordVM> HashTags { get; set; } = new List<HashTagRecordVM>();
    }
}
