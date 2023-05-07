using Crop_Deal1.Models;
using Microsoft.EntityFrameworkCore;
namespace Crop_Deal1.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Crop> Crops { get; set; }

        public DbSet<Crop_detail> Crop_details { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public  DbSet<Bank_detail> Bank_details { get; set;}
    }
}
