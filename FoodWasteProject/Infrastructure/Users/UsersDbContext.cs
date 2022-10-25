/* User's module - Core Dummpers
 * Collaboratos:
 * - Álvaro Miranda
 * - Nathan Miranda
 * - Mariana Murillo
 * - Emmanuel Zúñiga
 * 
 * - Summary: Creates a dbContext with the User, Client, PersonalUser and ConfirmationCode mappings.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain.Users.Entities;
using Infrastructure.Users.EntityMappings;

namespace Infrastructure.Users
{
    public class UsersDbContext : ApplicationDbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options, ILogger<UsersDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Administrator> Administrators { get; set; } = null!;
        public DbSet<PersonalUser> PersonalUsers { get; set; } = null!;
        public DbSet<BusinessUser> BusinessUsers { get; set; } = null!;
        public DbSet<ConfirmationCode> ConfirmationCodes { get; set; } = null!;

        public DbSet<UserFoodPreferences> UserFoodPreferences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AdministratorMap());
            modelBuilder.ApplyConfiguration(new PersonalUserMap());
            modelBuilder.ApplyConfiguration(new BusinessUserMap());
            modelBuilder.ApplyConfiguration(new ConfirmationCodeMap());
            modelBuilder.ApplyConfiguration(new UserFoodPreferencesMap());
        }
    }
}
