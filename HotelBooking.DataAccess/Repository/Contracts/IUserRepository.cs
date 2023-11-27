using HotelBooking.Entities;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByUsername(string username);
        Task<List<User>> GetUsers();
        Task<int> Create(User user);
        Task Update(User user);
        Task Delete(User user);

    }
}
