using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Notification
    {
        public String Content { get; set; }
        public List<Passenger> Recipients { get; set; }
    }
}