/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Allergen entity
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

namespace Infrastructure.Products.EntityMappings
{
    public class AllergenMap : IEntityTypeConfiguration<Allergen>
    {
        public void Configure(EntityTypeBuilder<Allergen> builder)
        {
            // Mapping to table Restrinction
            builder.ToTable("Allergen");
            // Mapping table ids
            builder.HasKey(t =>  t.Name);
            builder.HasKey(t => t.Category);
            // Mapping attribute of table
            builder.Property(p => p.Description);

        }
    }
}
