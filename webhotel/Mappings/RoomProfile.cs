using AutoMapper;
using HotelBooking.BookingDTO.RoomDtos;

namespace HotelBooking.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
        }
    }
}
