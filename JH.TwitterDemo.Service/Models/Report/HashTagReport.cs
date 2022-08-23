using System.Collections.Generic;

namespace JH.TwitterDemo.Service.Models.Report
{
    public class HashTagReport
    {
        public int TotalTwitts { get; set; }
        public IEnumerable<HashTagRecord> HashTags { get; set; } = new List<HashTagRecord>();
    }
}