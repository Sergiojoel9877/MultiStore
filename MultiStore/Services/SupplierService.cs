﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        bool disposedValue;

        public SupplierService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Supplier entity)
        {
            await UnitOfWork.SupplierRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.SupplierRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Supplier> Get(int id)
        {
            var data = await UnitOfWork.SupplierRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Supplier>>();
            try
            {
                var data = UnitOfWork.SupplierRepository.GetAll();
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

        public void Update(Supplier article)
        {
            UnitOfWork.SupplierRepository.Update(article);
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


