using HotelBooking.Entities;

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
