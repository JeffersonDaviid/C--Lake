using APIv1.models;
using Microsoft.EntityFrameworkCore;

namespace APIv1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}