using HotelBooking.Services.Contracts;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

public class TokenServiceTest
{
    [Fact]
    public void GenerateToken_ShouldGenerateValidToken()
    {
        // Arrange
        ITokenService tokenService = new TokenService();
        string username = "testuser";
        int userId = 123;

        // Act
        string token = tokenService.GenerateToken(username, userId);

        // Assert
        Assert.NotNull(token);
        Assert.True(token.Length > 0);
        Assert.True(tokenService.ValidateToken(token));
    }

    [Fact]
    public void ValidateToken_WithValidToken_ShouldReturnTrue()
    {
        // Arrange
        ITokenService tokenService = new TokenService();
        string token = tokenService.GenerateToken("testuser", 123);

        // Act
        bool isValid = tokenService.ValidateToken(token);

        // Assert
        Assert.True(isValid);
    }

    [Fact]
    public void ValidateToken_WithInvalidToken_ShouldReturnFalse()
    {
        // Arrange
        ITokenService tokenService = new TokenService();
        string invalidToken = "invalidtoken";

        // Act
        bool isValid = tokenService.ValidateToken(invalidToken);

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void GetClaimValue_ShouldReturnCorrectClaimValue()
    {
        // Arrange
        ITokenService tokenService = new TokenService();
        string token = tokenService.GenerateToken("testuser", 123);
        string claimType = "username";

        // Act
        string claimValue = tokenService.GetClaimValue(token, claimType);

        // Assert
        Assert.Equal("testuser", claimValue);
    }

    [Fact]
    public void GetClaimsFromToken_ShouldReturnClaims()
    {
        // Arrange
        ITokenService tokenService = new TokenService();
        string token = tokenService.GenerateToken("testuser", 123);

        // Act
        IEnumerable<Claim> claims = tokenService.GetClaimsFromToken(token);

        // Assert
        Assert.NotNull(claims);
        Assert.True(claims.Any());
    }
}
