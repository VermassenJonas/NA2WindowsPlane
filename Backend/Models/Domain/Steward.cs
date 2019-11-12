using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Steward
    {
        public String FirstName { get; set; }
        public String Name { get; set; }
        [Key]
        public int PersonnelNumber { get; set; }
        public String Password { get; set; }
        public String Hash { get; set; }
    }
}