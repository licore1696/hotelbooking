using HotelBooking.BookingDTO;

namespace HotelBooking.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<int> Create(UserDto userDto);
        Task<List<UserDto>> GetUsers();
        Task<UserDto> Update(UserDto userDto);
        Task<bool> Delete(int id);
    }
}