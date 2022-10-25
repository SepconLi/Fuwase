/* CD-US-2.2 Forgot my password - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for ConfirmationCode entity.
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
    public class ConfirmationCodeMap : IEntityTypeConfiguration<ConfirmationCode>
    {
        public void Configure(EntityTypeBuilder<ConfirmationCode> builder)
        {
            builder.ToTable("ConfirmationCode");
            builder.HasKey(e => e.Email);
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
