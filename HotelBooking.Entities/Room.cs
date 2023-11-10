using HotelBooking.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Room
{
    public int Id { get; set; }
    public string RoomType { get; set; }
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

   

    
}
