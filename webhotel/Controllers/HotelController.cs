using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.DataAccess;
using HotelBooking.BookingDTO;
using HotelBooking.Services.Contracts;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking/Hotel")]
    public class HotelController : ControllerBase
    {
        public readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<HotelDto>> GetById(int id)
        {
            return await _hotelService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] HotelDto hotel)
        {
            return await _hotelService.Create(hotel);
        }

        [HttpGet("hotels")]
        public async Task<ActionResult<List<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HotelDto hotelDto)
        {
            var updatedHotelDto = await _hotelService.Update(hotelDto);

            if (updatedHotelDto == null)
            {
                return NotFound();
            }

            return Ok(updatedHotelDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hotelService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}