using System;
using System.Collections.Generic;

namespace HRManagement.Data.Entities
{
    public class OffDay:BaseEntity
    {
        public OffDay()
        {
            PersonelOffDays = new HashSet<PersonelOffDay>();
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? OffDayLimit { get; set; }
        public string OffDayType { get; set; }
        public ICollection<PersonelOffDay> PersonelOffDays { get; set; }

    }
}
