using Crop_Deal1.Data;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal1.Repository
{
    public class Bank_detailRepository : IBank_detail
    {
        private readonly ApiDbContext context;

        public Bank_detailRepository(ApiDbContext context)
        {
            this.context = context;
        }
        public async Task<Bank_detail> CreateBank_acc(Bank_detail user)
        {
            await context.Bank_details.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Bank_detail> DeleteBank_acc(int id)
        {
            var user = await context.Bank_details.FirstOrDefaultAsync(x => x.Bank_detailid == id);
            if (user == null)
            {
                return null;
            }
            context.Bank_details.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Bank_detail> GetBank_detail(int id)
        {
            var user = await context.Bank_details.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<Bank_detail>> GetBank_details()
        {
           return await context.Bank_details.ToListAsync();
        }

        public async Task<Bank_detail> UpdateBank_detail(int id, Bank_detail user)
        {
            var u = await context.Bank_details.FindAsync(id);
            if (u == null)
            {
                return null;
            }
            u.Bank_detailid = id;
            u.Account_no = user.Account_no;
            u.Bank_name = user.Bank_name;
            u.IFSC = user.IFSC;

            await context.SaveChangesAsync();

            return u;
        }
    }
}
