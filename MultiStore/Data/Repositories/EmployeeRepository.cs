using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }
    }
}
