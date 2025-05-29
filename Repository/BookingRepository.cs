using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.BookingDTO;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBooking(Booking bookingModel)
        {
            await _context.Bookings.AddAsync(bookingModel);
            await _context.SaveChangesAsync();

            return bookingModel;
        }

        public async Task<Booking?> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null)
            {
                return null;
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        public async Task<List<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetByID(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<Booking?> UpdateBooking(int id, UpdateBookingDTO bookingDTO)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null)
            {
                return null;
            }

            booking.Status = bookingDTO.Status;
            booking.BookingDate = bookingDTO.BookingDate;

            await _context.SaveChangesAsync();
            return booking;
        }
    }
}