using System.Threading.Tasks;

namespace JH.TwitterDemo.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}