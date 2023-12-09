using HotelBooking.BookingDTO.HotelDtos;
using HotelBooking.BookingDTO.Search;
using HotelBooking.Services.Contracts;
using System.Net.Http.Json;

namespace HotelBooking.Web.Requests
{
    public class ApiHotelService : IHotelService
	{
		protected readonly HttpClient _httpClient;

		public ApiHotelService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task<int> Create(HotelDto hotelDto)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<HotelDto>> GetAvailableHotels(SearchDto searchDto)
		{
			var response = await _httpClient.PostAsJsonAsync($"api/HotelBooking/Hotel/GetAvailableHotels",searchDto);
			if(response.IsSuccessStatusCode) { 
				List<HotelDto> avaliablehotels = await response.Content.ReadAsAsync<List<HotelDto>>();
				return avaliablehotels;
			}
			else
			{
				throw new HttpRequestException($"Failed to get hotels. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}");
			}
		}

		public async Task<HotelDto> GetById(int id)
		{
			var response = await _httpClient.GetAsync($"api/HotelBooking/Hotel/{id}");
			if(response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsAsync<HotelDto>();
			}
			else { throw new HttpRequestException($"Failed to get hotels. Status code: {response.StatusCode}. Reason: {response.ReasonPhrase}"); }
		}

		public Task<List<HotelDto>> GetHotels()
		{
			throw new NotImplementedException();
		}

        public async Task<List<string>> GetImagesById(int id)
        {
			var response = await _httpClient.GetFromJsonAsync<List<string>>($"api/HotelBooking/Hotel/images/{id}");
            return response ?? throw new HttpRequestException("Couldn't get images");
        }
      

        public Task<HotelImageDto> SetImages(HotelImageDto hotelImageDto)
        {
            throw new NotImplementedException();
        }

        public Task<HotelDto> Update(HotelDto hotelDto)
		{
			throw new NotImplementedException();
		}
	}
}
