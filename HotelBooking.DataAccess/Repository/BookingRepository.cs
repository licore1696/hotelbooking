using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(BookingContext context) : base(context)
        {
        }

        public async Task<int> Create(Booking booking)
        {
           _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task Delete(Booking booking)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetById(int id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
