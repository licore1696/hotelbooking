using HotelBooking.Entities;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IBookingRepository
    {
        Task<Booking> GetById(int id);
        Task<List<Booking>> GetBookings();
        Task<int> Create(Booking booking);
        Task Update(Booking booking);
        Task Delete(Booking booking);
        Task<List<Booking>> GetBookingsByRoomIdAndDate(int roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<Booking>> GetBookingsByUser(int userId);
    }
}
