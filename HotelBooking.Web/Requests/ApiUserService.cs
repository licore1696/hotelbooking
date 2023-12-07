using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Services.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Web.Requests
{
    public class ApiUserService : IUserService
    {
        protected readonly HttpClient _httpClient;
        private readonly ApiTokenService _tokenService;
        private readonly ILogger<ApiUserService> _logger;

        public ApiUserService(HttpClient httpClient, ApiTokenService tokenService, ILogger<ApiUserService> logger)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<int> Create(UserDto userDto)
        {
            
                var response = await _httpClient.PostAsJsonAsync("api/HotelBooking/User", userDto);
                int userId = -1;
                if(response != null) { 
                         userId = await response.Content.ReadFromJsonAsync<int>();
                }
                response.EnsureSuccessStatusCode();

                
                return userId;
        }

        public async Task<bool> Delete(int id)
            
        {
            await SetAuthorizationHeader();

            var response = await _httpClient.DeleteAsync($"api/HotelBooking/User/token/{id}");
            
            
            return await response.Content.ReadAsAsync<bool>();

        }

        public async Task<UserDto> GetById(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<UserDto>($"api/HotelBooking/User/GetById/{id}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting user by ID: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDto> GetByUsername(string username)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<UserDto>($"api/HotelBooking/User/GetByUsername/{username}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting user by username: {ex.Message}");
                return null;
            }
        }

        public async Task<UpdateUserDto> GetProfile(int id)
        {
            
            try
            {
                await SetAuthorizationHeader();
                var response = await _httpClient.GetFromJsonAsync<UpdateUserDto>($"api/HotelBooking/User/token/getprofile/{id}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error getting user by ID: {ex.Message}");
                return null;
            }
        }

        public async Task<List<UserDto>> GetUsers()
        { 
				var response = await _httpClient.GetFromJsonAsync<List<UserDto>>($"api/HotelBooking/User/Users");
				return response ?? throw new HttpRequestException("Couldn't get users");
		}

        public async Task<int> IfCanLogin(string username, string password)
        {
            var httpResponse = await _httpClient.GetAsync($"api/HotelBooking/User/CanLogin?username={username}&password={password}");

            if (httpResponse.IsSuccessStatusCode)
            {
               
                var userId = await httpResponse.Content.ReadFromJsonAsync<int>();
                if (userId != -1)
                {
                    
                    return userId;
                }
            }

            
            return -1;
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            
            var response = await _httpClient.PutAsJsonAsync($"api/HotelBooking/User/update",userDto);


            if (response.IsSuccessStatusCode)
            {

                var updatedUserDto = await response.Content.ReadAsAsync<UserDto>();

                return updatedUserDto;
            }

            else
            {
                
                throw new HttpRequestException($"Failed to update user. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
            }

        }

        public async Task<UpdateUserDto> UpdateUser(UpdateUserDto updateUserDto)
        {
            await SetAuthorizationHeader();

            
            

            var response = await _httpClient.PutAsJsonAsync("api/HotelBooking/User/token/updateAccount", updateUserDto);

            if (response.IsSuccessStatusCode)
            {
                var updatedUserDto = await response.Content.ReadAsAsync<UpdateUserDto>();
                return updatedUserDto;
            }
            else
            {
                throw new HttpRequestException($"Failed to update user. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
            }
        }

        private async Task SetAuthorizationHeader()
        {
            
            var token = await _tokenService.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                _logger.LogInformation("Authorization header set successfully");
            }
            else
            {
                _logger.LogWarning("Token is null or empty");
            }
        }
    }
}
