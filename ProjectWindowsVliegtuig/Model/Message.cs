using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Model
{
    public class Message
    {
        public String Content { get; set; }
        public DateTime Sent { get; set; }
        public String Sender { get; set; }
        public String Alignment { get; set; }
    }
}
