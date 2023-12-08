using HotelBooking.BookingDTO.BookingDTOs;

namespace HotelBooking.Services.Contracts
{
    public interface IBookingService
    {
        Task<BookingDto> GetById(int id);
        Task<int> Create(BookingDto bookingDto);
        Task<List<BookingDto>> GetBookings();
        Task<BookingDto> Update(BookingDto bookingDto);
        Task<bool> Delete(int id);
        Task<List<BookingDto>> GetBookingsByUserId(int userId);
    }
}
