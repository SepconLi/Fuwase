/* User's module - Imborrables
 * Collaboratos:
 * - Fabian Gonzalez
 * - Maeva Murcia
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
    public class UserFoodPreferencesMap : IEntityTypeConfiguration<UserFoodPreferences>
    {
        public void Configure(EntityTypeBuilder<UserFoodPreferences> builder)
        {
            builder.ToTable("UserPreferences");

            // Mapping table ids
            builder.HasKey(t => new { t.UserEmail, t.FoodRestriction });
            builder.Property(p => p.FoodRestriction).HasColumnName("FoodRestriction");
            // builder.HasOne(p => p.UserFoodPreferences).WithMany(p => p.FoodRestriction).HasForeignKey(p => new { p.UserEmail });
            // builder.HasOne(p => p.User).WithOne(p => p.UserFoodPreference).HasForeignKey(p => p.UserEmail); ;
        }
    }
}
