using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Entities;
using HotelBooking.DataAccess;
using System;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{

    [ApiController]
    [Route("api/HotelBooking")]
    public class BookingController : ControllerBase
    {
        private readonly BookingContext _context;

        public BookingController(BookingContext context)
        {
            _context = context;
        }

        [HttpGet("bookings")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        var bookings = await _context.Set<Booking>().ToListAsync();
        return bookings;
    }

    [HttpGet("bookings/{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Set<Booking>().FindAsync(id);

        if (booking == null)
        {
            return NotFound();
        }

        return booking;
    }

    [HttpPost("bookings")]
    public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
    {
        _context.Set<Booking>().Add(booking);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
    }

    [HttpPut("bookings")]
    public async Task<IActionResult> UpdateBooking(Booking booking)
    {
            var bookingToupdate = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == booking.Id);
            if (bookingToupdate == null) { return NotFound(); }
            bookingToupdate.UserId = booking.UserId;
            bookingToupdate.RoomId = booking.RoomId;
            bookingToupdate.CheckInDate = booking.CheckInDate;
            bookingToupdate.CheckOutDate = booking.CheckOutDate; 
            bookingToupdate.TotalPrice = booking.TotalPrice;
            bookingToupdate.Status = booking.Status;
            bookingToupdate.Comments = booking.Comments;
            _context.Update(bookingToupdate);

            await _context.SaveChangesAsync();

            return Ok();

    }

    [HttpDelete("bookings/{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Set<Booking>().FindAsync(id);

        if (booking == null)
        {
            return NotFound();
        }

        _context.Set<Booking>().Remove(booking);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookingExists(int id)
    {
        return _context.Set<Booking>().Any(e => e.Id == id);
    }
}
}