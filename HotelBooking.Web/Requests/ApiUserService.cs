using HotelBooking.BookingDTO.UserDTOs;
using HotelBooking.Entities;
using HotelBooking.Services.Contracts;
using System.Net.Http.Json;


namespace HotelBooking.Web.Requests
{
    public class ApiUserService : IUserService
    {
        protected readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            var response = await _httpClient.DeleteAsync($"api/HotelBooking/User/{id}");
            
            
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
                var response = await _httpClient.GetFromJsonAsync<UpdateUserDto>($"api/HotelBooking/User/getprofile/{id}");
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
            var response =await _httpClient.PutAsJsonAsync($"api/HotelBooking/User/updateAccount", updateUserDto);

            if(response.IsSuccessStatusCode)
            {
                var updatedUserDto = await response.Content.ReadAsAsync<UpdateUserDto>();

                return updatedUserDto;
            }
            else
            {
                throw new HttpRequestException($"Failed to update user. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
            }
        }
    }
}
