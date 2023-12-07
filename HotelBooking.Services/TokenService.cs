using HotelBooking.Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService: ITokenService
{
    private readonly string secretKey = "0EECF46B06BC5BC25D9CF887779BBFD1FC3C2EC75F708B6C05A6E101D6A6A231"; 

    public string GenerateToken(string username, int userId)
    {
        var claims = new List<Claim>
        {
            new Claim("username", username),
            new Claim("userid", userId.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddSeconds(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = key,
                ValidateIssuer = false,  
                ValidateAudience = false,  
                ClockSkew = TimeSpan.Zero
            }, out _);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<Claim> GetClaimsFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        return jsonToken?.Claims;
    }

    public string GetClaimValue(string token, string claimType)
    {
        var claims = GetClaimsFromToken(token);
        var claim = claims.FirstOrDefault(c => c.Type == claimType);

        return claim.Value;
    }
}
