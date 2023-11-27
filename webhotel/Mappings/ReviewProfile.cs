using AutoMapper;
using HotelBooking.BookingDTO.ReviewDtos;
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
