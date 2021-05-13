using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRManagement.Data.Entities
{
    public class Company :BaseEntity
    {
       
        
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int TelNumber { get; set; }
        public int TaxNumber { get; set; }
        public ICollection<Personel> Personels { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
        [DataType(DataType.Url)]
        public string Logo { get; set; }

    }
}
