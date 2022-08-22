using JH.TwitterDemo.Data.Context;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories
{
    public class TwittRepository : BaseRepository<Twitt, TwitterDBContext>, ITwittRepository
    {
        public TwittRepository(TwitterDBContext context) : base(context)
        {
        }

        public async Task<int> TotalCount()
        {
            return await this.context.Twitts.CountAsync();
        }
    }
}