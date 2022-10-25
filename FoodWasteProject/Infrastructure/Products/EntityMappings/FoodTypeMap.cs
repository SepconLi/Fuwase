/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for FoodType entity
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
    public class FoodTypeMap : IEntityTypeConfiguration<FoodType>
    {
        public void Configure(EntityTypeBuilder<FoodType> builder)
        {
            // Mapping to table FoodType
            builder.ToTable("FoodType");
            // Mapping table id
            builder.HasKey(t => t.Name);
        }
    }
}
