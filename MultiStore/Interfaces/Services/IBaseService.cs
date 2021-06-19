using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;

namespace MultiStore.Interfaces.Services
{
    public interface IBaseService<T> : IDisposable where T : BaseEntity, new()
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        void Update(T article);
        Task Delete(int id);
    }
}
