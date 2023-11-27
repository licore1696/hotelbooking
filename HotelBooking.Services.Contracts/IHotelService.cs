using HotelBooking.BookingDTO.HotelDtos;

namespace HotelBooking.Services.Contracts
{
    public interface IHotelService
    {
        Task<HotelDto> GetById(int id);
        Task<int> Create(HotelDto hotelDto);
        Task<List<HotelDto>> GetHotels();
        Task<HotelDto> Update(HotelDto hotelDto);
        Task<bool> Delete(int id);
    }
}
