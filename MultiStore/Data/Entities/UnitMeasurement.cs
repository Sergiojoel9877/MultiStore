using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class UnitMeasurement : BaseEntity
    {
        public string Description { get; set; }
        public List<Article> Articles { get; set; }
        public List<ArticleRequest> ArticleRequests { get; set; }
        public List<PurchaseOrder> PurchaseOrders { get; set; }
    }
}