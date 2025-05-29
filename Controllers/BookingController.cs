using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.BookingDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/Bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepo;
        public BookingController(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooking()
        {
            var booking = await _bookingRepo.GetAllBookings();
            return Ok(booking);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var booking = await _bookingRepo.GetByID(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingRequestDTO bookingRequestDTO)
        {
            var booking = bookingRequestDTO.NewBooking();
            await _bookingRepo.CreateBooking(booking);

            return CreatedAtAction(nameof(GetById), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking([FromRoute] int id, [FromBody] UpdateBookingDTO bookingDTO)
        {
            var booking = await _bookingRepo.UpdateBooking(id, bookingDTO);
            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = bookingDTO.Status;
            booking.BookingDate = bookingDTO.BookingDate;

            return Ok(booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var booking = await _bookingRepo.DeleteBooking(id);
            if (booking == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}