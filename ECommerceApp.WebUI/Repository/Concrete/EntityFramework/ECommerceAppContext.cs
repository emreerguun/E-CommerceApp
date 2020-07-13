using ECommerceApp.WebUI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Repository.Concrete.EntityFramework
{
    public class ECommerceAppContext:DbContext
    {
        public ECommerceAppContext(DbContextOptions<ECommerceAppContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductAttribute> Attributes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(pk => new { pk.ProductId, pk.CategoryId });
        }

    }
}
