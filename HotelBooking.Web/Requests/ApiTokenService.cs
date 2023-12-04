using HotelBooking.BookingDTO.TokenDtos;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
namespace HotelBooking.Web.Requests
{
    


public class ApiTokenService
    {
        private readonly IJSRuntime _jsRuntime;
        protected readonly HttpClient _httpClient;

        public ApiTokenService(IJSRuntime jsRuntime, HttpClient httpClient)
        {  
            _jsRuntime = jsRuntime;
            _httpClient = httpClient;
        }

        public async Task<string> GetToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem","token");
        }

        public async Task SetToken(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem","token",token);

        }

        public async Task RemoveToken()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "token");
        }

        public async Task<string> AuthenticateAndSetToken(string username, int userId)
        {
            
            var response = await _httpClient.PostAsJsonAsync("/api/token/generate", new TokenDto
            {
                Username = username,
                UserId = userId
            });

            if (response.IsSuccessStatusCode)
            {
                
                var result = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
                await SetToken(result.Token);
                return result.Token;
            }
            else
            {
                
                return null;
            }
        }

        public async Task<int> GetUserIdFromToken()
        {
            var token = await GetToken();

            if (string.IsNullOrEmpty(token))
            {
                return -1;
            }

            var userIdResponse = await _httpClient.GetAsync($"/api/token/getId/{token}");

            if (!userIdResponse.IsSuccessStatusCode)
            {
                return -1;
            }

            var userIdString = await userIdResponse.Content.ReadAsStringAsync();

            if (int.TryParse(userIdString, out var userId))
            {
                return userId;
            }
            else
            {
                return -1;
            }
        }

        private class AuthenticationResponse
        {
            public string Token { get; set; }
        }
    }

}

