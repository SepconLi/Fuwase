using Domain.Orders.Entities;
using Domain.Products.Entities;
using Domain.Users.Entities;
using Domain.Donations.Entities;
using Infrastructure.Core;
using Infrastructure.Orders.EntityMappings;
using Infrastructure.Products.EntityMappings;
using Infrastructure.Users.EntityMappings;
using Infrastructure.Donations.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Orders
{
    public class OrderDbContext : ApplicationDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options, ILogger<OrderDbContext> logger) : base(options, logger)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Donation> Donations { get; set; } = null!;
        public DbSet<PersonalUser> PersonalUsers { get; set; } = null!;
        public DbSet<BusinessUser> BusinessUsers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public DbSet<Restriction> Restrictions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BusinessUserMap());
            modelBuilder.ApplyConfiguration(new PersonalUserMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());
            modelBuilder.ApplyConfiguration(new RestrictionMap());
        }

    }
}
