using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Entities;
using HotelBooking.DataAccess;
using HotelBooking.Services.Contracts;
using HotelBooking.BookingDTO;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/HotelBooking/User")]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] UserDto user)
        {
            return await _userService.Create(user);
        }

        [HttpGet("Users")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            var updatedUserDto = await _userService.Update(userDto);

            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return Ok(updatedUserDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}