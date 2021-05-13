using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Data.Entities
{
   
    public class BaseUserEntity:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
       
        public DateTime BirthDay { get; set; }
        public UserRole Role { get; set; }

    }
}
