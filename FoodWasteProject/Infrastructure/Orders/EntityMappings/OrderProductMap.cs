using Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Orders.EntityMappings
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            // Mapping to table Order
            builder.ToTable("OrderProduct");
            // Mapping table id
            builder.HasKey(op => new { op.OrderId, op.ProductId });

            // Mapping Properties
            builder.Property(p => p.Quantity);
            
            // Mapping Many-to-Many relationship
            builder.HasOne(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(op => new {op.ProductId });
            builder.HasOne(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(op => op.OrderId);

        }
    }
}
