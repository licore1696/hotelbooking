using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Entities;

namespace HotelBooking.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        //Task<int> Update(User user);
        //Task<int> Delete(int id);  

    }
}
