using HotelBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IReviewRepository
    {
        Task<Review> GetById(int id);
        Task<List<Review>> GetReviews();
        Task<int> Create(Review review);
        Task Update(Review review);
        Task Delete(Review review);
    }
}
