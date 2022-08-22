namespace JH.TwitterDemo.Data.Entities
{
    public class HashTag : IEntity
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }
}