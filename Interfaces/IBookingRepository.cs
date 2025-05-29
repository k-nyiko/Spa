using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BookingDTO;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookings();
        Task<Booking?> GetByID(int id);
        Task<Booking> CreateBooking(Booking bookingModel);
        Task<Booking?> UpdateBooking(int id, UpdateBookingDTO bookingDTO);
        Task<Booking?> DeleteBooking(int id);
    }
}