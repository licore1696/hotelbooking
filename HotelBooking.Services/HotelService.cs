using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.DataAccess.Repository;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class HotelService : IHotelService
    {
        public readonly IHotelRepository _hotelRepository;
        public readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
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
    }
}
