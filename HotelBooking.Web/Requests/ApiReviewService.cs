using HotelBooking.BookingDTO.ReviewDtos;
using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Services.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HotelBooking.Web.Requests
{
    public class ApiReviewService : IReviewService
    {
        protected readonly HttpClient _httpClient;
        private readonly ApiTokenService _tokenService;

        public ApiReviewService(HttpClient httpClient, ApiTokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<int> Create(ReviewDto reviewDto)
        {
                await SetAuthorizationHeader();
                var response = await _httpClient.PostAsJsonAsync("api/HotelBooking/Review/token/Review", reviewDto);
                int reviewId = -1;
                if (response != null)
                {
                    reviewId = await response.Content.ReadFromJsonAsync<int>();
                }
                response.EnsureSuccessStatusCode();


                return reviewId;
            
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewDto>> GetReviews()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReviewDto>>($"api/HotelBooking/Review/Reviews");
            return response ?? throw new HttpRequestException("Couldn't get reviews");
        }

        public Task<ReviewDto> Update(ReviewDto reviewDto)
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
            
        }
    }
}
