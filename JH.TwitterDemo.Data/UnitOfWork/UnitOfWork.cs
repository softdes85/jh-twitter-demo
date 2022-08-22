using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            this._context = context;
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}