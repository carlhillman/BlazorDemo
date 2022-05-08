using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDemo.Models;

namespace BlazorDemo.DataAccess.Services
{
    public interface IUserDataService
    {
        Task<int> GetLastInsertedUserId();
        Task<User> GetUser(int id);
        Task<List<User>> GetUsers();
        Task<bool> InsertUser(User person);
        Task<bool> UpdateUser(int id, User person);
        Task<bool> DeleteUser(int id);

    }
}
