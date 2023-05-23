using Crop_Deal1.Dtos;
using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(int id,Userdto user);
        Task<User> DeleteUser(int id);
        Task<User> FindUser(string username);
         
    }
}
