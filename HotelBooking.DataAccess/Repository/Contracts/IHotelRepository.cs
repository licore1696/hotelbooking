namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IHotelRepository
    {
        Task<Hotel> GetById(int id);
        Task<List<Hotel>> GetHotels();
        Task<int> Create(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(Hotel hotel);
    }
}
