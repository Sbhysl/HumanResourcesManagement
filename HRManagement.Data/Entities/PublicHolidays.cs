using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Data.Entities
{
    public class PublicHolidays:BaseEntity
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
