using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }

        //Create anothe rel, which services did the customer book
        public int? ServiceId { get; set; }
        public Service? service { get; set; }
    }
}