using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IHotelRepository
    {
        Task<Hotel> GetById(int id);
        Task<List<Hotel>> GetHotels();
        Task<int> Create(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(Hotel hotel);
    }
}
