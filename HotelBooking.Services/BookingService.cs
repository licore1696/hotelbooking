using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.DataAccess.Repository;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Entities;
using HotelBooking.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class BookingService : IBookingService
    {
        public readonly IBookingRepository _bookingRepository;
        public readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(BookingDto bookingDto)
        {
            var bookingToAdd = _mapper.Map<Booking>(bookingDto);

            return await _bookingRepository.Create(bookingToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var bookingToDelete = await _bookingRepository.GetById(id);
            if (bookingToDelete == null)
            {
                return false;
            }
            await _bookingRepository.Delete(bookingToDelete);
            return true;
        }

        public async Task<List<BookingDto>> GetBookings()
        {
            var bookings = await _bookingRepository.GetBookings();
            return _mapper.Map<List<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetById(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> Update(BookingDto bookingDto)
        {
            var existingBooking = await _bookingRepository.GetById(bookingDto.Id);

            if (existingBooking == null)
            {
                return null;
            }

            _mapper.Map(bookingDto, existingBooking);

            await _bookingRepository.Update(existingBooking);

            return _mapper.Map<BookingDto>(existingBooking);
        }
    }
}
