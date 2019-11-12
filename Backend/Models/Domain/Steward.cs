using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Steward
    {
        public String FirstName { get; set; }
        public String Name { get; set; }
        public int PersonnelNumber { get; set; }
        public String Password { get; set; }
        public String Hash { get; set; }
    }
}