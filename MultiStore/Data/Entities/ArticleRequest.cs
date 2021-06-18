namespace MultiStore.Data.Entities
{
    public class ArticleRequest : BaseEntity
    {
        public int Stock { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int UnitMeasurementId { get; set; }
        public UnitMeasurement UnitMeasurement { get; set; }
    }
}
