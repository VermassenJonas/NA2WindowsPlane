using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Medium
    {
        [Key]
        public int MediumId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public List<String> Tags { get; set; }
    }
}