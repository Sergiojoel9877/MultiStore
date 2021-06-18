using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class ArticleRequestRepository : BaseRepository<ArticleRequest>, IArticleRequestRepository
    {
        public ArticleRequestRepository(ApplicationDbContext context) : base(context) { }
    }
}
