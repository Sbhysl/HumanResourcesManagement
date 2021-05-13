using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Data.Entities
{
    public class PersonelOffDay
    {
        public long PersonelID { get; set; }
        public Personel Personel { get; set; }
        public long OffDayID { get; set; }
        public OffDay OffDay { get; set; }
    }
}
