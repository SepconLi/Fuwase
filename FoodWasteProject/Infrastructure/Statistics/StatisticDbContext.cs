/* Statistics module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a dbContext with the Statistics
 */

/* Project includes */
using Domain.Statistics.Entities;
using Infrastructure.Core;
using Infrastructure.Statistics.EntityMappings;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Statistics
{
    public class StatisticDbContext : ApplicationDbContext {
        public StatisticDbContext(DbContextOptions<StatisticDbContext> options,
            ILogger<StatisticDbContext> logger) : base(options, logger) { }

        // Declaring DbSets
        public DbSet<Statistic> Statistics { get; set; } = null!;   
        public DbSet<ProvinceStats> Provinces { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StatisticMap());
            modelBuilder.ApplyConfiguration(new ProvinceStatsMap());
        }
    }
}