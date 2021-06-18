using System;
using System.Threading.Tasks;

namespace MultiStore.Interfaces.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
