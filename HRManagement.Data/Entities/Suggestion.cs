using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Data.Entities
{
    public class Suggestion:BaseEntity
    {
    
        public SuggestionTypes SuggestionTypes { get; set; }
        public string Description { get; set; }
        public long CompanyID { get; set; }
        public Company Company { get; set; }
        public bool IsChecked { get; set; }
    }
}
