namespace HotelBooking.BookingDTO.HotelDtos
{
    public class CreateHotelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; }
    }
}
