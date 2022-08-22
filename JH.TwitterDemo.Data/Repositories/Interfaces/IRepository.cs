using JH.TwitterDemo.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
    }
}
