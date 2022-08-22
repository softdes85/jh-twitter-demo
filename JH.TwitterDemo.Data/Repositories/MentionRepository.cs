using JH.TwitterDemo.Data.Context;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;

namespace JH.TwitterDemo.Data.Repositories
{
    public class MentionRepository : BaseRepository<Mention, TwitterDBContext>, IMentionRepository
    {
        public MentionRepository(TwitterDBContext context) : base(context)
        {
        }
    }
}