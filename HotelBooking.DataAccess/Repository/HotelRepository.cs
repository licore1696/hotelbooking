using HotelBooking.DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(BookingContext context) : base(context)
        {
        }

        public async Task<int> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel.Id;
        }

        public async Task Delete(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public Task<Hotel> GetById(int id)
        {
            return _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
