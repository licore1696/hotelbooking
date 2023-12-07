using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int? UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        
        public User User { get; set; }

    }


}
