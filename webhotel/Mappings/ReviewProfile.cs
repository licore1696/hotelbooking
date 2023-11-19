using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.Entities;

namespace HotelBooking.Mappings
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() 
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
        }
    }
}
