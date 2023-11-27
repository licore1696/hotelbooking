using Microsoft.AspNetCore.Mvc;
using HotelBooking.Services.Contracts;
using HotelBooking.BookingDTO.UserDTOs;

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



        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet("GetByUsername/{Username}")]
        public async Task<ActionResult<UserDto>> GetByUsername(string Username)
        {
            return await _userService.GetByUsername(Username);
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

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            var updatedUserDto = await _userService.Update(userDto);

            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return Ok(updatedUserDto);
        }

        [HttpPut("updateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateUserDto updateUserDto)
        {
            var updatedUserDto = await _userService.UpdateUser(updateUserDto);

            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpGet("CanLogin")]
        public async Task<int> CanLogin(string username, string password)
        {
            var result = await _userService.IfCanLogin(username, password);
            if (result == -1) { return -1; }
            return result;
        }

        [HttpGet("getprofile/{id}")]
        public async Task<ActionResult<UpdateUserDto>> GetProfile(int id)
        {
            return await _userService.GetProfile(id);
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