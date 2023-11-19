using AutoMapper;
using HotelBooking.BookingDTO;
using HotelBooking.DataAccess.Repository.Contracts;
using HotelBooking.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Services
{
    public class RoomService : IRoomService
    {
        public readonly IRoomRepository _roomRepository;
        public readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(RoomDto roomDto)
        {
            var roomToAdd = _mapper.Map<Room>(roomDto);

            return await _roomRepository.Create(roomToAdd);
        }

        public async Task<bool> Delete(int id)
        {
            var roomToDelete = await _roomRepository.GetById(id);
            if (roomToDelete == null) 
            { 
                return false;
            }
            await _roomRepository.Delete(roomToDelete);
            return true;
        }

        public async Task<RoomDto> GetById(int id)
        {
            var room = await _roomRepository.GetById(id);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<List<RoomDto>> GetRooms()
        {
            var rooms = await _roomRepository.GetRooms();
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public async Task<RoomDto> Update(RoomDto roomDto)
        {
            var existingRoom = await _roomRepository.GetById(roomDto.Id);

            if (existingRoom == null)
            {
                return null;
            }

            _mapper.Map(roomDto,existingRoom);

            await _roomRepository.Update(existingRoom);
            
            return _mapper.Map<RoomDto>(existingRoom);

        }
    }
}
