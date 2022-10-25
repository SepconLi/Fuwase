/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * 
 * - Summary: Creates a map for Campaign entity
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
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            // Mapping to table Campaign
            builder.ToTable("Campaign");
            // Mapping table id
            builder.HasKey(t => new { t.Id });
            // Mapping attributes of table
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); // To indicate the attribute name
                                        // and indicate that this value is auto incremented
            builder.HasMany(t => t.Products).WithOne(p => p.Campaign!);
            builder.Property(t => t.CreatorEmail);
            builder.Property(t => t.Name);
            builder.Property(t => t.Description);
            builder.Property(t => t.StartDate);
            builder.Property(t => t.EndDate);
            builder.Property(t => t.Goal);
            builder.Property(t => t.Raised);
            builder.Property(t => t.Delivered);
            builder.Property(t => t.Province);
            builder.Property(t => t.County);
            builder.Property(t => t.District);
            builder.Property(t => t.ExactLocation);
            builder.Property(t => t.Type);
            builder.Property(t => t.Status);
        }
    }
}