using MultiStore.Data.Entities;
using MultiStore.Interfaces.Repositories;

namespace MultiStore.Data.Repositories
{
    public class UnitMeasurementRepository : BaseRepository<UnitMeasurement>, IUnitMeasurementRepository
    {
        public UnitMeasurementRepository(ApplicationDbContext context) : base(context) { }
    }
}
