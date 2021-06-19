using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data.Entities;
using MultiStore.Data.Repositories;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class ArticleRequestService : BaseService, IArticleRequestService
    {
        bool disposedValue;

        public ArticleRequestService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(ArticleRequest entity)
        {
            await UnitOfWork.ArticleRequestRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.ArticleRequestRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<ArticleRequest> Get(int id)
        {
            var data = await UnitOfWork.ArticleRequestRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<ArticleRequest>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<ArticleRequest>>();
            try
            {
                var data = UnitOfWork.ArticleRequestRepository.GetAll();
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

        public async Task Update(ArticleRequest article)
        {
            await Task.Yield();
            UnitOfWork.ArticleRequestRepository.Update(article);
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
