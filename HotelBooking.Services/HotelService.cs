using AutoMapper;
using HotelBooking.BookingDTO.HotelDtos;
using HotelBooking.BookingDTO.RoomDtos;
using HotelBooking.BookingDTO.Search;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Services.Contracts;

namespace HotelBooking.Services
{
    public class HotelService : IHotelService
    {
        public readonly IHotelRepository _hotelRepository;
        public readonly IRoomRepository _roomRepository;
        public readonly IMapper _mapper;
        public IRoomService _roomService;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper,IRoomService roomService,IRoomRepository roomRepository)
        {
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _roomService = roomService;
        }

        public HotelService()
        {
        }

        public async Task<int> Create(HotelDto hotelDto)
        {
            var hotelToAdd = _mapper.Map<Hotel>(hotelDto);

            return await _hotelRepository.Create(hotelToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var hotelToDelete = await _hotelRepository.GetById(id);
            if (hotelToDelete == null)
            {
                return false;
            }
            await _hotelRepository.Delete(hotelToDelete);
            return true;
        }

        public async Task<HotelDto> GetById(int id)
        {
            var hotel = await _hotelRepository.GetById(id);
            return _mapper.Map<HotelDto>(hotel);
        }

        public async Task<List<HotelDto>> GetHotels()
        {
            var hotels = await _hotelRepository.GetHotels();
            return _mapper.Map<List<HotelDto>>(hotels);
        }

        public async Task<HotelDto> Update(HotelDto hotelDto)
        {
            var existingHotel = await _hotelRepository.GetById(hotelDto.Id);

            if (existingHotel == null)
            {
                return null;
            }

            _mapper.Map(hotelDto, existingHotel);

            await _hotelRepository.Update(existingHotel);

            return _mapper.Map<HotelDto>(existingHotel);
        }

        public async Task<List<HotelDto>> GetAvailableHotels(SearchDto searchDto) {

            List <HotelDto> availableHotels = new List<HotelDto>();    
		    var hotelsInCountry = await _hotelRepository.GetHotelsByCountryAndCity(searchDto.Country, searchDto.City);//rooms count
            
            foreach (var hotel in hotelsInCountry)
            {
                if (searchDto != null && searchDto.Checkin != null && searchDto.CheckOut != null)
                {
                    var availableRooms = await _roomRepository.GetAvailableRoomsByHotelIdAndDate(hotel.Id, searchDto.Checkin, searchDto.CheckOut);
                        
                    
                   
                     if (IsSubsetWithRepeats(availableRooms, searchDto.TypeRooms))
                     {
                        availableHotels.Add(_mapper.Map<HotelDto>(hotel));
                     }
                }

            }
			return _mapper.Map<List<HotelDto>>(availableHotels);
        
        
        }
        public bool IsSubsetWithRepeats(List<Room> rooms, List<RoomCardDto> cards)
		{
			var capacityCounterA = new Dictionary<int, int>();
			var capacityCounterB = new Dictionary<int, int>();

			foreach (var room in rooms)
			{
				if (capacityCounterA.ContainsKey(room.Capacity))
					capacityCounterA[room.Capacity]++;
				else
					capacityCounterA[room.Capacity] = 1;
			}

			foreach (var card in cards)
			{
				if (capacityCounterB.ContainsKey(card.Capacity))
					capacityCounterB[card.Capacity]++;
				else
					capacityCounterB[card.Capacity] = 1;
			}

			return capacityCounterB.All(kv => capacityCounterA.ContainsKey(kv.Key) && capacityCounterA[kv.Key] >= kv.Value);
		}

        public async Task<List<string>> GetImagesById(int id)
        {
            return await _hotelRepository.GetImagesByHotel(id);
        }

        public async Task<HotelImageDto> SetImages(HotelImageDto hotelImageDto)
        {
            var existingHotel = await _hotelRepository.GetById(hotelImageDto.Id);
            if (existingHotel == null)
            {
                return null;
            }

            _mapper.Map(hotelImageDto, existingHotel);

            await _hotelRepository.Update(existingHotel);

            return _mapper.Map<HotelImageDto>(existingHotel);

       
        }
    }
}
