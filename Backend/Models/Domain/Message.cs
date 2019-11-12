using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Message
    {
        public List<Passenger> recipients { get; set; }
        public String Message { get; set; }
    }
}