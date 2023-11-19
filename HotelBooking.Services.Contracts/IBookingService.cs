using HotelBooking.BookingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services.Contracts
{
    public interface IBookingService
    {
        Task<BookingDto> GetById(int id);
        Task<int> Create(BookingDto bookingDto);
        Task<List<BookingDto>> GetBookings();
        Task<BookingDto> Update(BookingDto bookingDto);
        Task<bool> Delete(int id);
    }
}
