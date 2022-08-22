using System;
using System.Collections.Generic;
using System.Text;

namespace JH.TwitterDemo.Service.Models.Report
{
    public class HashTagReport
    {
        public int TotalTwitts { get; set; }
        public IEnumerable<HashTagRecord> HashTags { get; set; }= new List<HashTagRecord>();
    }
    public class HashTagRecord
    {
        public string Tag { get; set; }
        public int NumberOfReferences { get; set; }
    }
}
