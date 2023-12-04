
using HotelBooking.Services.Contracts;

namespace HotelBooking.Midleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenService _tokenService;

        public TokenMiddleware(RequestDelegate next, TokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (RequiresAuthorization(context))
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (!string.IsNullOrEmpty(token) && _tokenService.ValidateToken(token))
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
            
           return context.Request.Path.StartsWithSegments("/api/HotelBooking/User/updateAccount");
           
        }
    }

}
