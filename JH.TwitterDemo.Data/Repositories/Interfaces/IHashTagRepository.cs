using JH.TwitterDemo.Data.Dtos;
using JH.TwitterDemo.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories.Interfaces
{
    public interface IHashTagRepository : IRepository<HashTag>
    {
        Task<List<HashTagCount>> TopNAsync(int topN);
    }
}