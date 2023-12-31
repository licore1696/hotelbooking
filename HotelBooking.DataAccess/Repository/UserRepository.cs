﻿using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DataAccess.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(BookingContext context) : base(context)
        {
        }

        public async Task<int> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        
    }
}