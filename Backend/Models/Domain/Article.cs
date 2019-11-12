using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Article
    {
        public String Name { get; set; }
        public decimal price { get; set; }
        public int Stock { get; set; }
    }
}