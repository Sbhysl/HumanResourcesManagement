using System;

namespace HRManagement.Data.Entities
{
    public class BaseEntity
    {
        public long ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
