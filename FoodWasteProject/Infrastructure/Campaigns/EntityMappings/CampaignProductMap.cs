/* Campaign module - Asociación Lista y Valiente & Imborrables
 * Collaborators:
 * - Jimena Gdur
 * - Fabian Gonzales
 * - Maeva Murcia
 * 
 * - Summary: Creates a map for CampaignProduct entity
 */

/* Project includes */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Campaigns.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Campaigns.EntityMappings
{
    public class CampaignProductMap : IEntityTypeConfiguration<CampaignProduct>
    {
        public void Configure(EntityTypeBuilder<CampaignProduct> builder)
        {
            // Mapping to table Restrinction
            builder.ToTable("CampaignProduct");
            // Mapping table ids
            builder.HasKey(p => new { p.Id });
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); // To indicate the attribute name
                                        // and indicate that this value is auto incremented

            // Mapping attributes of table

            builder.HasOne(p => p.Campaign).WithMany(p => p.Products)
                .HasForeignKey(p => p.CampaignId);
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.FoodType);
            builder.Property(p => p.ProductType);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.Weight);
            builder.Property(p => p.Goal);
            builder.Property(p => p.Raised);
        }
    }
}
