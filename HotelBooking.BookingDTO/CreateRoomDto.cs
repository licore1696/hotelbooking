using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BookingDTO
{
    public class CreateRoomDto
    {
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        //public int HotelId { get; set; }
    }
}
