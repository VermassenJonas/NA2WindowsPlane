using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Flight
    {
        public String Destination { get; set; }
        public String Origin { get; set; }
        public DateTime ETA { get; set; }
        public List<Passenger> Passengers { get; set; }
        public List<Steward> Stewards { get; set; }
        public List<Order> Orders { get; set; }
    }
}