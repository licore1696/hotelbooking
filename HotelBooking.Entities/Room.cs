using HotelBooking.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    public int Id { get; set; }
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    
    public int HotelId { get; set; }

    [ForeignKey("HotelId")]
    public Hotel Hotel { get; set; }

    public List<Booking> Bookings { get; set; }
}
