using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Entities;
using HotelBooking.DataAccess;
using HotelBooking.Services.Contracts;
using HotelBooking.BookingDTO;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] UserDto user)
        {
            return await _userService.Create(user);
        }
    }
}