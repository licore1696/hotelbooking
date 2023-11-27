using AutoMapper;
using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Entities;

namespace HotelBooking.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, CreateUpdateUserDto>().ReverseMap();
        }
    }
}
