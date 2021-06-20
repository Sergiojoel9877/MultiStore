﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        bool disposedValue;

        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Employee entity)
        {
            await UnitOfWork.EmployeeRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.EmployeeRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Employee> Get(int id)
        {
            var data = await UnitOfWork.EmployeeRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Employee>>();
            try
            {
                var data = UnitOfWork.EmployeeRepository.GetAll();
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

        public void Update(Employee article)
        {
            UnitOfWork.EmployeeRepository.Update(article);
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


