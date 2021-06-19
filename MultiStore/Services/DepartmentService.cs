using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Data.Repositories;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class DepartmentService : IDepartmentService
    {
        bool disposedValue;

        readonly UnitOfWork UnitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (UnitOfWork)unitOfWork;
        }

        public async Task Create(Department entity)
        {
            await UnitOfWork.DepartmentRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.DepartmentRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Department> Get(int id)
        {
            var data = await UnitOfWork.DepartmentRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Department>>();
            try
            {
                var data = UnitOfWork.DepartmentRepository.GetAll();
                tcs.SetResult(data);
                return await tcs.Task;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ex {ex}");
                tcs.SetResult(null);
                tcs.SetException(ex);
                return await tcs.Task;
            }
        }

        public async Task Update(Department article)
        {
            await Task.Yield();
            UnitOfWork.DepartmentRepository.Update(article);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UnitOfWork?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}


