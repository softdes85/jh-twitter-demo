using System.Collections.Generic;

namespace JH.TwitterDemo.Data.Entities
{
    public class Twitt : IEntity
    {
        public int Id { get; set; }
        public string TwitterId { get; set; }
        public string Text { get; set; }
        public ICollection<HashTag> HashTags = new List<HashTag>();
        public ICollection<Mention> Mentions = new List<Mention>();
    }
}