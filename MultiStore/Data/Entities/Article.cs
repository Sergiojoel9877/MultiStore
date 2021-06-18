using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class Article : BaseEntity
    {
        public string Description { get; set; }
        public int Stock { get; set; }
        
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        
        public int UnitMeasurementId { get; set; }
        public UnitMeasurement UniteMeasurement { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<ArticleRequest> ArticleRequests { get; set; }

        public List<Article> Articles { get; set; }

        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}