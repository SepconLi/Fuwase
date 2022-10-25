/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Donation entity
 */

/* Project includes */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Donations.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Donations.EntityMappings {
    public class DonationMap : IEntityTypeConfiguration<Donation> {
        public void Configure(EntityTypeBuilder<Donation> builder) {
            // Mapping to table Donation
            builder.ToTable("Donation");
            // Mapping table id
            builder.HasKey(t => new { t.Id });
            // Mapping attributes of table
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); // To indicate the attribute name
                            // and indicate that this value is auto incremented
            builder.HasMany(t => t.Products).WithOne(p => p.Donation!);
            builder.Property(t => t.DonorId);
            builder.Property(t => t.CreationDate);
            builder.Property(t => t.Status);
            builder.Property(t => t.Province);
            builder.Property(t => t.County);
            builder.Property(t => t.District);
            builder.Property(t => t.ExactLocation);
        }
    }
}