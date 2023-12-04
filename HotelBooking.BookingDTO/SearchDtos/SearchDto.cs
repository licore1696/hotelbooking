using HotelBooking.BookingDTO.RoomDtos;

namespace HotelBooking.BookingDTO.Search
{
	public class SearchDto
	{
			public string Country { get; set; }
			public string City { get; set; }
			public DateTime Checkin { get; set; }
			public DateTime CheckOut { get; set; }
			public List<RoomCardDto> TypeRooms { get; set; }
		
	}
}
