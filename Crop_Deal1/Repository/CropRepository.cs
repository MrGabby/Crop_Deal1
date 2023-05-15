using Crop_Deal1.Data;
using Crop_Deal1.Interface;
using Crop_Deal1.Models;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal1.Repository
{
    public class CropRepository : ICrop
    {
        private readonly ApiDbContext context;

        public CropRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Crop> CreateCrop(Crop user)
        {
            await context.Crops.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Crop> DeleteCrop(int id)
        {
            var user = await context.Crops.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            context.Crops.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<Crop> GetCrop(int id)
        {
            var user = await context.Crops.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await context.Crops.ToListAsync();
        }

        public async Task<Crop> UpdateCrop(int id, Crop user)
        {
            var u = await context.Crops.FindAsync(id);
            if (u == null)
            {
                return null;
            }
            u.Cropid = id;
            u.Crop_name = user.Crop_name;
            u.Crop_image = user.Crop_image;
           

            await context.SaveChangesAsync();

            return u;
        }
    }
}
