namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IRoomRepository
    {
        Task<Room> GetById(int id);
        Task<List<Room>> GetRooms();
        Task<int> Create(Room room);
        Task Update(Room room);
        Task Delete(Room room);
		Task<List<Room>> GetAvailableRoomsByHotelIdAndDate(int hotelId, DateTime checkInDate, DateTime checkOutDate);
	}
}
