
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Crop_Deal1.Data;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal1.Repository
 
{ 
    public class UserRepository : IUser
    { 
        private readonly ApiDbContext context;

        public UserRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUser(User user)
        {
          await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> DeleteUser(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x=>x.Userid==id);
            if (user == null)
            {
                return null;
            }
             context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id, User i)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            user.Userid = id;
            user.Name = i.Name;
            user.Password = i.Password;
            user.Email_id = i.Email_id;
            user.Contact = i.Contact;
            user.Address = i.Address;
            user.Roles = i.Roles;
            user.Is_subscribe = i.Is_subscribe;

            context.SaveChangesAsync();

            return user;
        }

    }
}
