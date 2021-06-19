using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Data.Repositories;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class UnitMeasurementService : BaseService, IUnitMeasurementService
    {
        bool disposedValue;

        public UnitMeasurementService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(UnitMeasurement entity)
        {
            await UnitOfWork.UnitMeasurementRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.UnitMeasurementRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<UnitMeasurement> Get(int id)
        {
            var data = await UnitOfWork.UnitMeasurementRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<UnitMeasurement>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<UnitMeasurement>>();
            try
            {
                var data = UnitOfWork.UnitMeasurementRepository.GetAll();
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

        public void Update(UnitMeasurement article)
        {
            UnitOfWork.UnitMeasurementRepository.Update(article);
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


