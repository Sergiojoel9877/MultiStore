namespace MultiStore.Data.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public int OrderNumber { get; set; }
        public int Stock { get; set; }
        public int UnitCost { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int UnitMeasurementId { get; set; }
        public UnitMeasurement UnitMeasurement { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}