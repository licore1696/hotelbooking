using HotelBooking.BookingDTO;

namespace HotelBooking.Services.Contracts
{
    public interface IUserService
    {
       Task<UserDto> GetById(int id);
       Task<int> Create(UserDto userDto);
    }
}