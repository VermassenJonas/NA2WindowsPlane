using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Passenger
    {
        [Key]
        public int TicketNumber { get; set; }
        public String FirstName { get; set; }
        public String Name { get; set; }
        public Seat Seat { get; set; }
        public List<Order> Orders { get; set; }
        public TravelGroup TravelGroup { get; set; }
    }
}