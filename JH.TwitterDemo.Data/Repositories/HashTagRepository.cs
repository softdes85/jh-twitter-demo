
using JH.TwitterDemo.Data.Context;
using JH.TwitterDemo.Data.Dtos;
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories
{
    public class HashTagRepository : BaseRepository<HashTag, TwitterDBContext>, IHashTagRepository
    {
        public HashTagRepository(TwitterDBContext context) : base(context) { }

        public async Task<List<HashTagCount>> TopNAsync(int topN)
        {
            var hashes = this.context.HashTags.Take(100).ToList();
            var result = await this.context.HashTags
                .GroupBy(x => x.Tag)
                .Select(x => new HashTagCount() { Tag = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(topN)
                .ToListAsync();
            return result;
        }
    }
}
