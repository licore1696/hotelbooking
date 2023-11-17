using HotelBooking.BookingDTO;
using HotelBooking.Services.Contracts;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using AutoMapper;

namespace HotelBooking.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<int> Create(UserDto userDto)
        {
            var userToAdd = _mapper.Map<User>(userDto);

            return await _userRepository.Create(userToAdd);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            
            return _mapper.Map<UserDto>(user);
        }
    }
}