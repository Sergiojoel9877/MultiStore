using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}