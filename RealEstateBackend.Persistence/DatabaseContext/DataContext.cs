using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Domain;

namespace RealEstateBackend.Persistence.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RealEstateSchema");

            modelBuilder.Entity<Review>().ToTable("Review").HasKey(r => r.Id);
            modelBuilder.Entity<Review>().HasOne(r => r.User).WithMany(u => u.Reviews);

            modelBuilder.Entity<User>().ToTable("User").HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasMany(u => u.Reviews).WithOne(r => r.User);
            modelBuilder.Entity<User>().HasMany(u => u.Properties).WithOne(r => r.User);

            modelBuilder.Entity<Property>().ToTable("Property").HasKey(k => k.Id);
            modelBuilder.Entity<Property>().HasOne(p => p.User).WithMany(m => m.Properties);
            modelBuilder.Entity<Property>().HasMany(m => m.Images).WithOne(p => p.Property);

            modelBuilder.Entity<Image>().ToTable("Image").HasKey(k => k.Id);
            modelBuilder.Entity<Image>().HasOne(m => m.Property).WithMany(m => m.Images);

            modelBuilder.Entity<Auth>().ToTable("Auth").HasKey(k => k.Id);

        }
    }

}
