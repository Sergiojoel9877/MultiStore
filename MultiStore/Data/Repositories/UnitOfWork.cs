using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MultiStore.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly IBaseRepository<Article> _articleRepository;
        private readonly IBaseRepository<ArticleRequest> _articleRequestRepository;
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IBaseRepository<Department> _departmentRepository;
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IBaseRepository<PurchaseOrder> _purchaseOrderRepository;
        private readonly IBaseRepository<Supplier> _supplierRepository;
        private readonly IBaseRepository<UnitMeasurement> _unitMeasurementRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IArticleRepository ArticleRepository => (IArticleRepository)(_articleRepository ?? new ArticleRepository(_context));
        public IArticleRequestRepository ArticleRequestRepository => (IArticleRequestRepository)(_articleRequestRepository ?? new ArticleRequestRepository(_context));
        public IBrandRepository BrandRepository => (IBrandRepository)(_brandRepository ?? new BrandRepository(_context));
        public IDepartmentRepository DepartmentRepository => (IDepartmentRepository)(_departmentRepository ?? new DepartmentRepository(_context));
        public IEmployeeRepository EmployeeRepository => (IEmployeeRepository)(_employeeRepository ?? new EmployeeRepository(_context));
        public IPurchaseOrderRepository PurchaseOrderRepository => (IPurchaseOrderRepository)(_purchaseOrderRepository ?? new PurchaseOrderRepository(_context));
        public ISupplierRepository SupplierRepository => (ISupplierRepository)(_supplierRepository ?? new SupplierRepository(_context));
        public IUnitMeasurementRepository UnitMeasurementRepository => (IUnitMeasurementRepository)(_unitMeasurementRepository ?? new UnitMeasurementRepository(_context));

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
