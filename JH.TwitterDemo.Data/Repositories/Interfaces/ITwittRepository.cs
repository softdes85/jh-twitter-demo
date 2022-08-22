using JH.TwitterDemo.Data.Entities;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories.Interfaces
{
    public interface ITwittRepository : IRepository<Twitt>
    {
        public Task<int> TotalCount();
    }
}