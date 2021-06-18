using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class Brand : BaseEntity
    {
        public string Description { get; set; }
        public List<Article> Articles { get; set; }
        public List<PurchaseOrder> PurchaseOrder { get; set; }
    }
}