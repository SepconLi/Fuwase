/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for Client entity.
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
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.ToTable("Client");

            builder.Property(p => p.Province);

            builder.Property(p => p.District);

            builder.Property(p => p.Town);

            builder.Property(p => p.Strikes);
        }
    }
}
