/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Restriction entity
 */

/* Project includes */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Products.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Products.EntityMappings {
    public class RestrictionMap : IEntityTypeConfiguration<Restriction> {
        public void Configure(EntityTypeBuilder<Restriction> builder) {
            // Mapping to table Restrinction
            builder.ToTable("Restriction");
            // Mapping table ids
            builder.HasKey(t => new 
                { t.ProductId, t.FoodRestriction });
            builder.Property(p => p.FoodRestriction)
                .HasColumnName("FoodRestriction");
            builder.HasOne(p => p.Product).WithMany(p => p.Restrictions)
                .HasForeignKey(p => new { p.ProductId });
        }
    }
}
