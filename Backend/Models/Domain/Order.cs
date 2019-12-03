﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}