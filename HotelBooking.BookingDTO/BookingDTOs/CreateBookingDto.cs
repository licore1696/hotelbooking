namespace HotelBooking.BookingDTO.BookingDTOs
{
    public class CreateBookingDto
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
