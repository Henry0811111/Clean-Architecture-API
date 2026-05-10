using CleanArchG.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchG.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(e =>
        {
            e.Property(p => p.Price).HasPrecision(18, 2);
            e.Property(p => p.Name).IsRequired().HasMaxLength(200);

            // 1-till-många: Category → Products
            e.HasOne(p => p.Category)
             .WithMany(c => c.Products)
             .HasForeignKey(p => p.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed-data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Elektronik" },
            new Category { Id = 2, Name = "Kläder" }
        );
    }
}
