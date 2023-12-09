using HotelBooking.BookingDTO.TokenDtos;
using HotelBooking.Services.Contracts;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
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
            
            var response = await _httpClient.PostAsJsonAsync("/api/account/generate", new TokenDto
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
            await SetAuthorizationHeader();
            var userIdResponse = await _httpClient.GetAsync($"/api/account/getId/{token}");

            if (userIdResponse.IsSuccessStatusCode)
            {
            

                var userIdString = await userIdResponse.Content.ReadAsStringAsync();

                 int.TryParse(userIdString, out var userId);
                
                     return userId;
                
            }
            else
            {
                return -1;
            }
        }
        private async Task SetAuthorizationHeader()
        {

            var token = await GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            
        }
        private class AuthenticationResponse
        {
            public string Token { get; set; }
        }
    }

}

