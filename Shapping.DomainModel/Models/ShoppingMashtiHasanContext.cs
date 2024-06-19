using Microsoft.EntityFrameworkCore;
using Shapping.DomainModel.Models.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shapping.DomainModel.Models
{
    public class ShoppingMashtiHasanContext:DbContext
    {
        public ShoppingMashtiHasanContext(DbContextOptions<ShoppingMashtiHasanContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryFeature> CategoryFeatures { get; set; }

        public DbSet<Feature> Features{ get; set; }

        public DbSet<KeyWord> KeyWords{ get; set; }

        public DbSet<Order> Orders{ get; set; }

        public DbSet<OrderDetails> OrderDetails{ get; set; }

        public DbSet<Product> Products{ get; set; }

        public DbSet<ProductFeature> ProductFeatures{ get; set; }

        public DbSet<ProductKeyWord> ProductKeyWords { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfiguration());

            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordConfiguration());

            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());

            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());

            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration<Food>(new FoodConfiguration());

            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
