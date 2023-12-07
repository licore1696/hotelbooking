using System.Globalization;

namespace HotelBooking.Services.Contracts
{
    public interface IAccountService
    {
        string LogIn(string username, string password);
        bool LogOut();
    }
}
