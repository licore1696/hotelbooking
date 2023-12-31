﻿using HotelBooking.DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

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

		public async Task<List<Hotel>> GetHotelsByCountryAndCity(string country, string city)
		{
            return await _context.Hotels.Where(h => h.Country.Contains(country) && h.City.Contains(city)).ToListAsync();//выбирать по количеству комнат 
		}

        public async Task<List<string>> GetImagesByHotel(int id)
        {
            var hotel = await _context.Hotels
            .Where(h => h.Id == id)
            .FirstOrDefaultAsync();

            if (hotel != null)
            {
                // Assuming Images is not null, you might want to handle null case based on your requirements
                return hotel.Images ?? new List<string>();
            }

            return new List<string>();

        }

        public async Task Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
