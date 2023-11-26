using HotelBooking.BookingDTO;
using HotelBooking.Services.Contracts;
using HotelBooking.Web;
using System.Net.Http.Json;
using System.Net.Http.Formatting;
using System.Text.Json.Serialization;
using System.Text;
using static MudBlazor.CategoryTypes;


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
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/HotelBooking/User", userDto);
                Console.WriteLine(response);
                response.EnsureSuccessStatusCode();

                int userId = await response.Content.ReadFromJsonAsync<int>();
                return userId;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                
                return -1; 
            }
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

        public async Task<List<UserDto>> GetUsers()
        {
			try
			{
				var response = await _httpClient.GetFromJsonAsync<List<UserDto>>($"api/HotelBooking/User/Users");
				return response ?? new List<UserDto>();
			}
			catch (HttpRequestException ex)
            { 			
				Console.WriteLine($"Error getting users: {ex.Message}");
				return new List<UserDto>();
			}
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
    }
}
