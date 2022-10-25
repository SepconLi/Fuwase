/* Statistic module - Asociación Lista y Valiente
 * Collaborators:
 * - Jimena Gdur
 * - Rodrigo Li
 * - Daniela Murillo
 * - Milen Rodriguez
 * - Jorim Wilson
 * 
 * - Summary: Creates a map for Statistic entity
 */

/* Project includes */
using Domain.Statistics.Entities;
/* System includes */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Statistics.EntityMappings {
    public class ProvinceStatsMap : IEntityTypeConfiguration<ProvinceStats>
    {
        public void Configure(EntityTypeBuilder<ProvinceStats> builder) {
            // Mapping to table Statistics
            builder.ToSqlQuery("GetProvincesStats");
            // Mapping table id
            builder.HasKey(t => new { t.Name });
            // Mapping attributes of table
            builder.Property(t => t.Donations).HasColumnName("Donations");
        }
    }
}