using HotelBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IBookingRepository
    {
        Task<Booking> GetById(int id);
        Task<List<Booking>> GetBookings();
        Task<int> Create(Booking booking);
        Task Update(Booking booking);
        Task Delete(Booking booking);
    }
}
