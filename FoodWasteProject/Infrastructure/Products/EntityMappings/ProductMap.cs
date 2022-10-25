/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Product entity
 */

/* Project includes */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Donations.Entities;
using Domain.Orders.Entities;
using Domain.Products;
using Domain.Products.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products.EntityMappings 
{
    public class ProductMap : IEntityTypeConfiguration<Product> 
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            // Mapping to table Product
            builder.ToTable("Product");

            builder.HasKey(p => new { p.Id });
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); // To indicate the attribute name
                                        // and indicate that this value is auto incremented

            // Mapping attributes of table
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.FoodType);
            builder.Property(p => p.ProductType);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Weight);
            builder.Property(p => p.ExpirationDate);
            builder.Property(p => p.Brand);
            builder.Property(p => p.Image).HasDefaultValue();
            builder.HasOne(p => p.Donation).WithMany(p => p.Products)
                .HasForeignKey(p => p.DonationId);
            builder.HasMany(op => op.OrderProducts).WithOne(p => p.Product);
        }

    }
}
