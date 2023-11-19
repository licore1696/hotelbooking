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
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(BookingContext context) : base(context)
        {
        }

        public async Task<int> Create(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        public async Task Delete(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

        public async Task<Review> GetById(int id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task Update(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }
    }
}
