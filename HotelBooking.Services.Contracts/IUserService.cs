using HotelBooking.BookingDTO.UserDTOs;

namespace HotelBooking.Services.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<UserDto> GetByUsername(string username);
        Task<int> Create(UserDto userDto);
        Task<List<UserDto>> GetUsers();
        Task<UserDto> Update(UserDto userDto);
        Task<bool> Delete(int id);
        Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto);
        Task<UpdateUserDto> GetProfile(int id);
        Task<int> IfCanLogin(string username,string password);
    }
}