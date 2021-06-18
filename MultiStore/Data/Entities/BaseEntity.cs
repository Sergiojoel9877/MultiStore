using System;


namespace MultiStore.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}