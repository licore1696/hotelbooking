using AutoMapper;
using HotelBooking.BookingDTO.BookingDTOs;
using HotelBooking.Entities;

namespace HotelBooking.Mappings
{
    public class BookingProfile : Profile
    {
        public BookingProfile() 
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
        }
    }
}
