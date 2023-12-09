namespace HotelBooking.BookingDTO.RoomDtos
{
    public class CreateRoomDto
    {
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
    }
}
