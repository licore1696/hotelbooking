using Microsoft.AspNetCore.Mvc;
using HotelBooking.Services.Contracts;
using HotelBooking.BookingDTO;

namespace BookingBooking.Controllers
{

    [ApiController]
    [Route("api/HotelBooking/Booking")]
    public class BookingController : ControllerBase
    {
        public readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BookingDto>> GetById(int id)
        {
            return await _bookingService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] BookingDto booking)
        {
            return await _bookingService.Create(booking);
        }

        [HttpGet("bookings")]
        public async Task<ActionResult<List<BookingDto>>> GetBookings()
        {
            var bookings = await _bookingService.GetBookings();
            return Ok(bookings);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookingDto bookingDto)
        {
            var updatedBookingDto = await _bookingService.Update(bookingDto);

            if (updatedBookingDto == null)
            {
                return NotFound();
            }

            return Ok(updatedBookingDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}