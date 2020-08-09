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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(DataSettings.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(order =>
            {
                order
                 .HasMany(p => p.Products)
                 .WithOne(o => o.Order)
                 .HasForeignKey(k => k.OrderId);

                order
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
            });
        }
    }
}
