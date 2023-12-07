using HotelBooking.BookingDTO.HotelDtos;
using HotelBooking.BookingDTO.Search;
using HotelBooking.Services.Contracts;

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

		public Task<HotelDto> Update(HotelDto hotelDto)
		{
			throw new NotImplementedException();
		}
	}
}
