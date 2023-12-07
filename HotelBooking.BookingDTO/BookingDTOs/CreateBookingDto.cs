using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.BookingDTO.BookingDTOs
{
    public class CreateBookingDto
    {
        [Column(TypeName = "DATE")]
        public DateTime CheckInDate { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
