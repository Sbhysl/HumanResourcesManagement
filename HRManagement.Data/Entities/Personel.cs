using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.Data.Entities
{
    public class Personel:BaseUserEntity
    {
        public Personel()
        {
            PersonelOffDays = new HashSet<PersonelOffDay>();
        }
        public decimal? Expens { get; set; } //harcamalar
        public DateTime? PaymentsLastDay { get; set; }
        public DateTime HiredDate { get; set; }
        public string Phone { get; set; }
        public Departments Departments { get; set; }
        public long CompanyID { get; set; }
        public Company Company { get; set; }
        public string ProfilPicUrl { get; set; }

        public ICollection<PersonelOffDay> PersonelOffDays { get; set; }
        
        
    }
}
