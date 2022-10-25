/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Town entity
 */

/* Project includes */
using Domain.Locations.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Locations.EntityMappings
{
    public class TownMap : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            // Mapping to table Town
            builder.ToTable("Town");
            // Mapping table id
            builder.HasKey(t => t.Name);
            // Mapping attributes of table
            builder.Property(t => t.PName);
            builder.Property(t => t.DName);
        }
    }
}
