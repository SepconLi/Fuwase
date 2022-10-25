/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for Administrator entity.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Users;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Users.EntityMappings
{
    public class AdministratorMap : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {

            builder.ToTable("Administrator");

            builder.Property(p => p.AdminID);

            builder.Property(p => p.Name);

            builder.Property(p => p.LastName);

        }
    }
}
