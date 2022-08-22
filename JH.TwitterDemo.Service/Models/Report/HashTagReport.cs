using System.Collections.Generic;

namespace JH.TwitterDemo.Service.Models.Report
{
    public class HashTagReport
    {
        public int TotalTwitts { get; set; }
        public IEnumerable<HashTagRecord> HashTags { get; set; } = new List<HashTagRecord>();
    }

    public class HashTagRecord
    {
        public string Tag { get; set; }
        public int NumberOfReferences { get; set; }
    }
}