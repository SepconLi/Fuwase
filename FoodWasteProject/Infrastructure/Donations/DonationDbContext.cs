/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a dbContext with the Donation, Product, Restriction,
 *   Order, and OrderProduct mappings.
 */

/* Project includes */
using Domain.Donations.Entities;
using Domain.Orders.Entities;
using Domain.Products.Entities;
using Infrastructure.Core;
using Infrastructure.Donations.EntityMappings;
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

namespace Infrastructure.Donations
{
    public class DonationDbContext : ApplicationDbContext {
        public DonationDbContext(DbContextOptions<DonationDbContext> options,
            ILogger<DonationDbContext> logger) : base(options, logger) { }

        // Declaring DbSets
        public DbSet<Donation> Donations { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Restriction> Restrictions { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!; 

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DonationMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new RestrictionMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
        }
    }
}