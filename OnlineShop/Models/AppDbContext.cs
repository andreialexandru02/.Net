using Microsoft.EntityFrameworkCore;

namespace LeatherShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }
        protected override void OnConfiguring
       (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=LeatherShop;Integrated Security=True;MultipleActiveResultSets=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }

}
