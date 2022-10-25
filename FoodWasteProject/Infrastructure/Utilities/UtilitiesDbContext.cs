using Domain.Utilities.Entities;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Infrastructure.Users.EntityMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utilities.EntityMappings;

namespace Infrastructure.Utilities
{
    internal class UtilitiesDbContext : ApplicationDbContext
    {
        public UtilitiesDbContext(DbContextOptions<UtilitiesDbContext> options, ILogger<UtilitiesDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<RedirectInformation> RedirectInfo { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RedirectInformationMap());
        }
    }
}
