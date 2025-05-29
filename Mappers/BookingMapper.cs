using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BookingDTO;
using api.Models;

namespace api.Mappers
{
    public static class BookingMapper
    {
        public static Booking NewBooking(this BookingRequestDTO bookingRequestDTO)
        {
            return new Booking
            {
                Status = bookingRequestDTO.Status,
                BookingDate = bookingRequestDTO.BookingDate
            };
        }
    }
}