using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Transactions;

namespace Plugins.DataStore.SQL
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categorys> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorys>()
                 .HasMany(c => c.Products)
                 .WithOne(c=>c.Category)
                .HasForeignKey(p => p.CategoryId);


            // seeding some data
            modelBuilder.Entity<Categorys>().HasData(
                    new Categorys { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                    new Categorys { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                    new Categorys { CategoryId = 3, Name = "Meat", Description = "Meat" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
                );
        }
    }
}
