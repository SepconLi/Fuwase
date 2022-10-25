/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a map for BusinessUser entity.
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
    public class BusinessUserMap : IEntityTypeConfiguration<BusinessUser>
    {
        public void Configure(EntityTypeBuilder<BusinessUser> builder)
        {

            builder.ToTable("Business_User");

            builder.Property(p => p.Business_Name).IsRequired();

            builder.Property(p => p.Legal_Document).IsRequired();

            builder.Property(p => p.Alliance_Start).IsRequired();

            builder.Property(p => p.Person_In_Charge).IsRequired();

        }
    }
}
