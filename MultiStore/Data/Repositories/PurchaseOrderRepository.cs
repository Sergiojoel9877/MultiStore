using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ApplicationDbContext context) : base(context) { }
    }
}
