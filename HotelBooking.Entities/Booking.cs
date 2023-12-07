using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime CheckInDate { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // подтверждено, ожидает подтверждения, отменено 
        public string Comments { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }

}
