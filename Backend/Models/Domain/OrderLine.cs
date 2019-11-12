using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Article Article { get; set; }
        public int Amount { get; set; }

    }
}