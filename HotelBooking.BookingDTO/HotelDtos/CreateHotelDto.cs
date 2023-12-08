namespace HotelBooking.BookingDTO.HotelDtos
{
    public class CreateHotelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Stars { get; set; }
        public decimal PricePerNight { get; set; }
        public int Rating { get; set; }
    }
}
