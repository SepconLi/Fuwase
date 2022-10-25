/* Donation module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a dbContext with the Province, District,
 *   and Town mappings.
 */

using Infrastructure.Core;
using Domain.Locations.Entities;
using Infrastructure.Locations.EntityMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Locations
{
    public class LocationDBContext : ApplicationDbContext
    {
        public LocationDBContext(DbContextOptions<LocationDBContext> options, ILogger<LocationDBContext> logger) : base(options, logger)
        {
        }

        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<District> Districts { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProvinceMap());
            modelBuilder.ApplyConfiguration(new DistrictMap());
            modelBuilder.ApplyConfiguration(new TownMap());
        }
    }
}