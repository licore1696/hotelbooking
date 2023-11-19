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
            _mapper = mapper;
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

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var existingUser = await _userRepository.GetById(userDto.Id);

            if (existingUser == null)
            {
                return null;             }

            _mapper.Map(userDto, existingUser);

            await _userRepository.Update(existingUser);

            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task<bool> Delete(int id)
        {
            var userToDelete = await _userRepository.GetById(id);

            if (userToDelete == null)
            {
                return false; 
            }
            //удаление из мапинга
            await _userRepository.Delete(userToDelete);

            return true;
        }
    }
}