using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MultiStore.Data;
using MultiStore.Data.Entities;
using MultiStore.Data.Repositories;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;

namespace MultiStore.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        bool disposedValue;

        public ArticleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task Create(Article entity)
        {
            await UnitOfWork.ArticleRepository.Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.ArticleRepository.Delete(id);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Article> Get(int id)
        {
            var data = await UnitOfWork.ArticleRepository.GetById(id);
            return data ?? null;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Article>>();
            try
            {
                var data = UnitOfWork.ArticleRepository.GetAll();
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

        public void Update(Article article)
        {
            UnitOfWork.ArticleRepository.Update(article);
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
