/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for ProductType entity
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
    public class ProductTypeMap : IEntityTypeConfiguration<ProductType> 
    {
        public void Configure(EntityTypeBuilder<ProductType> builder) 
        {
            // Mapping to table ProductType
            builder.ToTable("ProductType");
            // Mapping table id
            builder.HasKey(t =>  t.Name);
        }
    }
}
