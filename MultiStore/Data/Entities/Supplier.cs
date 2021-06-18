using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class Supplier : BaseEntity
    {
        public string NationalTaxPayerRegistry { get; set; }
        public string CommercialName { get; set; }
        public List<Article> Articles { get; set; }
    }
}