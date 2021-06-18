using System;
using System.Collections.Generic;

namespace MultiStore.Data.Entities
{
    public class Employee : BaseEntity
    {
        public int IdentityCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth  { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<ArticleRequest> ArticleRequests { get; set; }
    }
}