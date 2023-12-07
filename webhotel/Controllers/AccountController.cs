using HotelBooking.BookingDTO.TokenDtos;
using HotelBooking.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateToken([FromBody] TokenDto model)
        {
            
            var token = _tokenService.GenerateToken(model.Username, model.UserId);

            return Ok(new { Token = token });
        }
        [HttpGet("getId/{token}")]
        public ActionResult<int> GetId(string token) {
            Console.WriteLine(token);
            var Id = _tokenService.GetClaimValue(token,"userid");
            return Ok(Id);
        }
        
    }

}
