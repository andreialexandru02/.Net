using _12_dec_2022.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thread = _12_dec_2022.Models.Thread;

namespace _12_dec_2022.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Thread> Threads { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }


    }
}