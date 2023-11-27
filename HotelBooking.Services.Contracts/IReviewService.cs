using HotelBooking.BookingDTO.ReviewDtos;

namespace HotelBooking.Services.Contracts
{
    public interface IReviewService
    {
        Task<ReviewDto> GetById(int id);
        Task<int> Create(ReviewDto reviewDto);
        Task<List<ReviewDto>> GetReviews();
        Task<ReviewDto> Update(ReviewDto reviewDto);
        Task<bool> Delete(int id);
    }
}
