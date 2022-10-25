/* Campaign module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - 
 * - 
 * 
 * - Summary: Creates a dbContext with the Campaign and Product mappings.
 */

/* Project includes */
using Domain.Campaigns.Entities;
using Infrastructure.Core;
using Infrastructure.Campaigns.EntityMappings;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Campaigns
{
    public class CampaignDbContext : ApplicationDbContext
    {
        public CampaignDbContext(DbContextOptions<CampaignDbContext> options,
            ILogger<CampaignDbContext> logger) : base(options, logger) { }

        // Declaring DbSets
        public DbSet<Campaign> Campaigns { get; set; } = null!;
        public DbSet<CampaignProduct> CampaignProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CampaignMap());
            modelBuilder.ApplyConfiguration(new CampaignProductMap());
        }
    }
}