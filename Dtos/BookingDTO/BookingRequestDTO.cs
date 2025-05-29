using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.BookingDTO
{
    public class BookingRequestDTO
    {
        public string Status { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
    }
}