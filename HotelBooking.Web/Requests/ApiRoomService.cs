using HotelBooking.BookingDTO.HotelDtos;
using HotelBooking.BookingDTO.RoomDtos;
using HotelBooking.BookingDTO.Search;
using HotelBooking.BookingDTO.SearchDtos;
using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Services.Contracts;
using System.Net.Http.Json;

namespace HotelBooking.Web.Requests
{
    public class ApiRoomService:IRoomService
    {
        protected readonly HttpClient _httpClient;
        private readonly ILogger<ApiUserService> _logger;

        public ApiRoomService(HttpClient httpClient, ILogger<ApiUserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public Task<int> Create(RoomDto roomDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoomDto>> GetFilteredRooms(FilterRoomDto filter)
        {
        
                var response = await _httpClient.PostAsJsonAsync($"api/HotelBooking/Room/FilterRoom",filter);
                if (response.IsSuccessStatusCode)
                {
                    List<RoomDto> avaliableRooms = await response.Content.ReadAsAsync<List<RoomDto>>();
                    return avaliableRooms;
                }
                else
                {
                    throw new HttpRequestException($"Failed to get hotels. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
                }
        }

        public Task<List<RoomDto>> GetRooms()
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> Update(RoomDto roomDto)
        {
            throw new NotImplementedException();
        }
    }
}
