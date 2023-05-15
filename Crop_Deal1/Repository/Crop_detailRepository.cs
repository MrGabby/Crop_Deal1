using Crop_Deal1.Data;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal1.Repository
{
    public class Crop_detailRepository : ICrop_detail
    {
        private readonly ApiDbContext context;

        public Crop_detailRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Crop_detail> CreateCrop(Crop_detail user)
        {
            await context.Crop_details.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Crop_detail> DeleteCrop_detail(int id)
        {
            var user = await context.Crop_details.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            context.Crop_details.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Crop_detail> GetCrop_detail(int id)
        {
            var user = await context.Crop_details.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<Crop_detail>> GetCrop_details()
        {
            return await context.Crop_details.ToListAsync();
        }

        public async Task<Crop_detail> UpdateCrop_detail(int id, Crop_detail user)
        {
            var u = await context.Crop_details.FindAsync(id);
            if (u == null)
            {
                return null;
            }
            u.Crop_detailid = id;
            u.Crop_name = user.Crop_name;
            u.Crop_type = user.Crop_type;
            u.CropDetail_description = user.CropDetail_description;
            u.Quantity = user.Quantity;
            u.Price = user.Price;
            u.Location = user.Location;

            await context.SaveChangesAsync();

            return u;
        }
    }

}
