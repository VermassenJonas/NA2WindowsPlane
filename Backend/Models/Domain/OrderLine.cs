using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class OrderLine
    {
        [Key]
        public int OrderLineId { get; set; }
        public Article Article { get; set; }
        public int Amount { get; set; }

    }
}