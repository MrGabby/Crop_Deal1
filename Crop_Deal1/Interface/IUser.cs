using Crop_Deal1.Models;

namespace Crop_Deal1.Interface
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(int id,User user);
        Task<User> DeleteUser(int id);
         
    }
}
