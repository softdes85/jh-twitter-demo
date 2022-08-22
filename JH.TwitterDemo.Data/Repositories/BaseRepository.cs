﻿
using JH.TwitterDemo.Data.Entities;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.Repositories
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;
        object lockObject = new object();
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            context.Add(entity);        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {            
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

    }
}
