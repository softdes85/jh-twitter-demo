using JH.TwitterDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JH.TwitterDemo.Data.Context
{
    public class TwitterDBContext : DbContext
    {
        public TwitterDBContext(DbContextOptions<TwitterDBContext> options) : base(options)
        {
        }

        public DbSet<Twitt> Twitts { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<Mention> Mentions { get; set; }
    }
}