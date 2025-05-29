using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; //This cannot be null
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }

        //Payment needs to know the booking/appointment we are paying for
        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }

    }
}