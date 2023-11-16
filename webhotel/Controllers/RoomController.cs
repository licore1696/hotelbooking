using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.DataAccess;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking")]
    public class RoomController : ControllerBase
    {
        private readonly BookingContext _context;

        public RoomController(BookingContext context)
        {
            _context = context;
        }

        [HttpGet("rooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
           return await _context.Set<Room>().ToListAsync();
        }
    

    [HttpGet("rooms/{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Set<Room>().FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return room;
    }

    [HttpPost("rooms")]
    public async Task<ActionResult<Room>> CreateRoom(Room room)
    {
        _context.Set<Room>().Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
    }

    [HttpPut("rooms/{id}")]
    public async Task<IActionResult> UpdateRoom(int id, Room room)
    {
        room.Id = id;

        _context.Entry(room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("rooms/{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Set<Room>().FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        _context.Set<Room>().Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoomExists(int id)
    {
        return _context.Set<Room>().Any(e => e.Id == id);
    }
}
}