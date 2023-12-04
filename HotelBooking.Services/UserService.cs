using AutoMapper;
using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using HotelBooking.Services.Contracts;

namespace HotelBooking.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<int> Create(UserDto userDto)
        {
            var userToAdd = _mapper.Map<User>(userDto);
            var existingUser = await _userRepository.GetByUsername(userToAdd.Username);
            if (existingUser == null) {
                userToAdd.Password = _passwordService.HashPassword(userToAdd.Password);

                return await _userRepository.Create(userToAdd); }
            return -1;
        }

        public async Task<UserDto> GetByUsername(string username)
        {
            var user = await _userRepository.GetByUsername(username);

            return _mapper.Map<UserDto>(user);
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

        public async Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto)
        {
            var userToUpdate = await _userRepository.GetById(updateUserDto.Id);

            if(userToUpdate == null)
            {
                return null;
            }

            _mapper.Map(updateUserDto, userToUpdate);

            await _userRepository.Update(userToUpdate);
            return _mapper.Map<UpdateUserDto>(userToUpdate);
            
        }

        public async Task<int> IfCanLogin(string username, string password)
        {
            var existingUser = await _userRepository.GetByUsername(username);
            if(existingUser == null)
            { return -1; }
            if (_passwordService.VerifyPassword(password, existingUser.Password))
            {
                return existingUser.Id;
            }
            return -1;
        }

        public async Task<UpdateUserDto> GetProfile(int id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UpdateUserDto>(user);

        }
    }
}