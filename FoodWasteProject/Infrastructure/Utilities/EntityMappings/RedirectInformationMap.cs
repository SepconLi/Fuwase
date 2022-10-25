/* CD-US-1.4 Add link to confirmation code email - Core Dummpers
 * 
 * Collaborators:
 * - Mariana Murillo
 * 
 * - Summary: Implementation of RedirectInformation Mapping
 */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Utilities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.EntityMappings
{
    public class RedirectInformationMap : IEntityTypeConfiguration<RedirectInformation>
    {
        public void Configure(EntityTypeBuilder<RedirectInformation> builder)
        {
            builder.ToTable("RedirectInformation");

            builder.HasKey(p => p.Hash);

            builder.Property(p => p.Email).IsRequired();

            builder.Property(p => p.Route).IsRequired();

            builder.Property(p => p.Param).IsRequired();

            builder.Property(p => p.Key).IsRequired();

            builder.Property(p => p.Expiration).IsRequired();
        }
    }
}
