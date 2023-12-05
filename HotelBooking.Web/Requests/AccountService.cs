using HotelBooking.Services.Contracts;

namespace HotelBooking.Web.Requests
{
    public class AccountService : IAccountService
    {
        protected readonly HttpClient _httpClient;
        private readonly ApiTokenService _tokenService;

        public AccountService(HttpClient httpClient, ApiTokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public string LogIn(string username, string password)
        {
            throw new NotImplementedException();//tokenservice

            /*
             generate
            settoken?
             
             
             */
        }
        //
        public bool LogOut()
        {
            throw new NotImplementedException();
            /*
             rmeovetoken?*/
        }
    }
}
