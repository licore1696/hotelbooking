using HotelBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IRoomRepository
    {
        Task<Room> GetById(int id);
        Task<List<Room>> GetRooms();
        Task<int> Create(Room room);
        Task Update(Room room);
        Task Delete(Room room);
    }
}
