using HotelBooking.BookingDTO.TokenDtos;
using HotelBooking.Entities;
using System.Security.Claims;

namespace HotelBooking.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(string username, int userId);
        bool ValidateToken(string token);
        IEnumerable<Claim> GetClaimsFromToken(string token);
        string GetClaimValue(string token, string claimType);
    }
}
