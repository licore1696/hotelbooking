﻿namespace HotelBooking.BookingDTO.ReviewDtos
{
    public class CreateReviewDto
    {
        public int HotelId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
