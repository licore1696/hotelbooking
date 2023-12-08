
using HotelBooking.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Midleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenService _tokenService;
        private readonly ILogger<TokenMiddleware> _logger;
        public TokenMiddleware(RequestDelegate next, ITokenService tokenService, ILogger<TokenMiddleware> logger)
        {
            _next = next;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (RequiresAuthorization(context))
            {

                var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                
                var token =  authorizationHeader.Substring("Bearer ".Length).Trim();
                _logger.LogInformation($"Authorization header value: {token}");
                if (_tokenService.ValidateToken(token))
                {
                    await _next(context);
                }
                else
                {
                    // Токен невалиден, отправляем ошибку
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                // Пропускаем запрос без авторизации
                await _next(context);
            }
        }

        private bool RequiresAuthorization(HttpContext context)
        {
            var pathsRequiringAuthorization = new List<string>
            {
                 "/api/HotelBooking/User/token",
                 "/api/account/getId",
                 "/api/HotelBooking/Booking/token",
            };

            return pathsRequiringAuthorization.Any(path => context.Request.Path.StartsWithSegments(path));
            
           
        }
    }

}
