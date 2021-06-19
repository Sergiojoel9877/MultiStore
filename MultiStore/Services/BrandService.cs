using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class BrandService : BaseService, IBrandService
    {
        bool disposedValue;

        public BrandService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Brand entity)
        {
            await UnitOfWork.BrandRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.BrandRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Brand> Get(int id)
        {
            var data = await UnitOfWork.BrandRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Brand>>();
            try
            {
                var data = UnitOfWork.BrandRepository.GetAll();
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

        public void Update(Brand article)
        {
            UnitOfWork.BrandRepository.Update(article);
            UnitOfWork.SaveChanges();
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

