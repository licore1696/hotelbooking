using AutoMapper;
using HotelBooking.BookingDTO.HotelDtos;

namespace HotelBooking.Mappings
{
    public class HotelProfile : Profile
    {
        public HotelProfile() 
        {
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, HotelImageDto>().ReverseMap();
        }
    }
}
