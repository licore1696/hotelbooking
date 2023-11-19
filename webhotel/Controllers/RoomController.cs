using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.DataAccess;
using HotelBooking.BookingDTO;
using HotelBooking.Services.Contracts;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking/Room")]
    public class RoomController : ControllerBase
    {
        public readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RoomDto>> GetById(int id)
        {
            return await _roomService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] RoomDto room)
        {
            return await _roomService.Create(room);
        }

        [HttpGet("Rooms")]
        public async Task<ActionResult<List<RoomDto>>> GetRooms()
        {
            var rooms = await _roomService.GetRooms();
            return Ok(rooms);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoomDto roomDto)
        {
            var updatedRoomDto = await _roomService.Update(roomDto);

            if (updatedRoomDto == null)
            {
                return NotFound();
            }

            return Ok(updatedRoomDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roomService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}