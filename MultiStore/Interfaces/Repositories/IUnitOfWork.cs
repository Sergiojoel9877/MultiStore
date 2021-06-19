using System;
using System.Threading.Tasks;

namespace MultiStore.Interfaces.Repositories
{
    public interface IUnitOfWork :IDisposable
    {
        public IArticleRepository ArticleRepository { get; }
        public IArticleRequestRepository ArticleRequestRepository { get; }
        public IBrandRepository BrandRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IPurchaseOrderRepository PurchaseOrderRepository { get; }
        public ISupplierRepository SupplierRepository { get; }
        public IUnitMeasurementRepository UnitMeasurementRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
