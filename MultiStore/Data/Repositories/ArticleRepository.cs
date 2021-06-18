using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context) : base(context){ }
    }
}
