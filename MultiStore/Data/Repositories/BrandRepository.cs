using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
    }
}
