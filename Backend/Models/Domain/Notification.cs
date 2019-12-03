using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Backend.Models.Domain
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public String Content { get; set; }
        public List<Passenger> Recipients { get; set; }
    }
}