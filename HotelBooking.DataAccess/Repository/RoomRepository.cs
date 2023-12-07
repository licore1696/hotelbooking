using HotelBooking.DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace HotelBooking.DataAccess.Repository
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(BookingContext context) : base(context)
        {
        }

        public async Task<int> Create(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room.Id;
        }

        public async Task Delete(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAvailableRoomsByHotelIdAndDate(int hotelId, DateTime checkInDate, DateTime checkOutDate)
        {
            var allRooms = await _context.Rooms
        .Include(r => r.Bookings)
        .Where(r => r.HotelId == hotelId)
        .ToListAsync();

            var availableRooms = allRooms
                .Where(room => !room.Bookings.Any(booking =>
                    (checkInDate <= booking.CheckOutDate && checkOutDate >= booking.CheckInDate)))
                .ToList();


            return availableRooms.ToList();
        }


        public async Task<Room> GetById(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task Update(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
