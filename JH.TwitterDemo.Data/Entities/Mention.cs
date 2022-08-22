namespace JH.TwitterDemo.Data.Entities
{
    public class Mention: IEntity 
    {
        public int Id { get; set; }
        public int Start { get; set; }
        public int End { get; set; }    
        public string UserName { get; set; }
        public string TwitterId { get; set; }
    }
}