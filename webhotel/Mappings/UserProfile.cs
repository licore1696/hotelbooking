using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.Entities;

namespace HotelBooking.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
