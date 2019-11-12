using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        public String SeatNumber { get; set; }
        //public List<Seat> AdjacentSeats { get; set; } if we need it.
    }
}