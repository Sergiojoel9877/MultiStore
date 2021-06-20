using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class PurchaseOrderService : BaseService, IPurchaseOrderService
    {
        bool disposedValue;

        public PurchaseOrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(PurchaseOrder entity)
        {
            await UnitOfWork.PurchaseOrderRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.PurchaseOrderRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<PurchaseOrder> Get(int id)
        {
            var data = await UnitOfWork.PurchaseOrderRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<PurchaseOrder>>();
            try
            {
                var data = UnitOfWork.PurchaseOrderRepository.GetAll();
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

        public void Update(PurchaseOrder article)
        {
            UnitOfWork.PurchaseOrderRepository.Update(article);
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


