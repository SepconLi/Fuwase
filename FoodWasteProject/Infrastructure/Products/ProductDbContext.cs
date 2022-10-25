/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a dbContext with the Product, Restriction, Allergen,
 *   AllergenCategory, ProductType, FoodType, Order, and OrderProduct mappings.
 */

/* Project includes */
using Domain.Orders.Entities;
using Domain.Products.Entities;
using Infrastructure.Core;
using Infrastructure.Orders.EntityMappings;
using Infrastructure.Products.EntityMappings;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products {
    public class ProductDbContext : ApplicationDbContext {
        public ProductDbContext(DbContextOptions<ProductDbContext> options, 
            ILogger<ProductDbContext> logger) : base(options, logger) {}

        // Declaring DbSets
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Restriction> Restrictions { get; set; } = null!;
        public DbSet<Allergen> Allergens { get; set; } = null!;
        public DbSet<AllergenCategory> AllergenCategories { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;
        public DbSet<FoodType> FoodTypes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RestrictionMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new AllergenMap());
            modelBuilder.ApplyConfiguration(new AllergenCategoryMap());
            modelBuilder.ApplyConfiguration(new FoodTypeMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
        }
    }
}
