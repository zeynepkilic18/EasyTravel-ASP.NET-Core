using Microsoft.EntityFrameworkCore;
using EasyTravel.Models;  // User modelini dahil etmek için.

namespace EasyTravel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }  
    }
}
