/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for User entity.
 */
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Users.EntityMappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("_User");

            builder.HasKey(p => p.Email);

            builder.Property(p => p.UserName).IsRequired();

            builder.Property(p => p.Password).IsRequired();

            builder.Property(p => p.PhoneNumber);

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.HashedEmail);

            builder.Property(p => p.Anom_Preference);

            builder.Property(p => p.Role);

            builder.Property(p => p.Profile_Picture);
        }
    }
}
