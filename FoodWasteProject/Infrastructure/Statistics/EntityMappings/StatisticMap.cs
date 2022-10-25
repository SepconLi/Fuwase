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
    public class StatisticMap : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder) {
            // Mapping to table Donation
            builder.ToTable("Statistic");
            // Mapping table id
            builder.HasKey(t => new { t.User_Id });
            // Mapping attributes of table
            builder.Property(t => t.User_Id).HasColumnName("User_Id");                                  
            builder.Property(t => t.Donation_Amount);
            builder.Property(t => t.Order_Amount);
            builder.Property(t => t.Donated_Weight);
           // builder.Property(t => t.App_Total_Donations).HasColumnName("App_Total_Donations");
        }
    }
}