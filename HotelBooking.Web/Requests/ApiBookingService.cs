using HotelBooking.BookingDTO.BookingDTOs;
using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Services.Contracts;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HotelBooking.Web.Requests
{
    public class ApiBookingService : IBookingService
    {
        protected readonly HttpClient _httpClient;
        private readonly ApiTokenService _tokenService;

        public ApiBookingService(HttpClient httpClient, ApiTokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<int> Create(BookingDto bookingDto)
        {

            var response = await _httpClient.PostAsJsonAsync("api/HotelBooking/Booking/Create", bookingDto);
            int bookingId = -1;
            if (response != null)
            {
                bookingId = await response.Content.ReadFromJsonAsync<int>();
            }
            response.EnsureSuccessStatusCode();


            return bookingId;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDto>> GetBookings()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookingDto>> GetBookingsByUserId(int userId)
        {
            await SetAuthorizationHeader();
            var response = await _httpClient.GetFromJsonAsync<List<BookingDto>>($"api/HotelBooking/Booking/token/BookingsByUser/{userId}");
            return response ?? throw new HttpRequestException("Couldn't get bookings");
        }

        

        public Task<BookingDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDto> Update(BookingDto bookingDto)
        {
            throw new NotImplementedException();
        }
        private async Task SetAuthorizationHeader()
        {

            var token = await _tokenService.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
            }
            else
            {
                
            }
        }

    }
}
