namespace HotelBooking.BookingDTO.SearchDtos
{
    public class FilterRoomDto
    {
        public int guests { get; set; }
        public int hotelId { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
