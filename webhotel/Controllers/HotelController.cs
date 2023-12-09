using HotelBooking.BookingDTO.HotelDtos;
using HotelBooking.BookingDTO.RoomDtos;
using HotelBooking.BookingDTO.Search;
using HotelBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using static HotelBooking.BookingDTO.Search.SearchDto;

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

		[HttpPost("GetAvailableHotels")]//или лучше просто get? причина post данные передачи(List)
		public async Task<ActionResult<List<HotelDto>>> GetAvailableHotels([FromBody] SearchDto searchDto)
		{
			return await _hotelService.GetAvailableHotels(searchDto);
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

        [HttpGet("images/{id}")]
        public async Task<ActionResult<List<string>>> GetImages(int id)
        {
            return await _hotelService.GetImagesById(id);
        }
        [HttpPut("setimages/")]
        public async Task<ActionResult<HotelImageDto>> SetImagesByHotelId(HotelImageDto hotelImageDto)
        {
            return await _hotelService.SetImages(hotelImageDto);
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