using Microsoft.EntityFrameworkCore;

namespace AndreiAlexandru42.Models
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
            @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ExamenDAW;Integrated Security=True;MultipleActiveResultSets=True");
        }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
