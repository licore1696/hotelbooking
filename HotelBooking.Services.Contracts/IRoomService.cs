using HotelBooking.BookingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services.Contracts
{
    public interface IRoomService
    {
        Task<RoomDto> GetById(int id);
        Task<int> Create(RoomDto roomDto);
        Task<List<RoomDto>> GetRooms();
        Task<RoomDto> Update(RoomDto roomDto);
        Task<bool> Delete(int id);
    }
}
