using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OZ.Models
{
    public class User
    {
        [Key]
        public Guid OID { get; set; }    
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; } 
        public bool Admin { get; set; }
        public bool Active { get; set; }
        public Guid? PlaceID { get; set; }
    }
}
