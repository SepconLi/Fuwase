/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for PersonalUser entity.
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
    public class PersonalUserMap : IEntityTypeConfiguration<PersonalUser>
    {
        public void Configure(EntityTypeBuilder<PersonalUser> builder) {

            builder.ToTable("Personal_User");

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.LastName).IsRequired();

            builder.Property(p => p.IdNumber).IsRequired();
            
        }
    }
}
