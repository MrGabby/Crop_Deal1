
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
    }
}
