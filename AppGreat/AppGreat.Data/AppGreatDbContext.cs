namespace AppGreat.Data
{
    using AppGreat.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class AppGreatDbContext : DbContext
    {
        public AppGreatDbContext(DbContextOptions<AppGreatDbContext> options)
             : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    
    }
}
