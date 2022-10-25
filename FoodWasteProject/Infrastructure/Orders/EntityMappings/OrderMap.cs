/*
+-Los Macacos
+
+Collaborators:
+-Josher Ramirez
+-Sirlany Mora
+-Aaron Campos
+-Estefany Ramirez
+-David Rojas
+
+-Summary: Component that returns the column and table name.
+*/
using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Orders;
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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Mapping to table Order
            builder.ToTable("Orders");
            // Mapping table id
            builder.HasKey(t => t.Id);
            // Mapping attributes of table
            builder.Property(t => t.OrderStatus);
            builder.Property(t => t.DonorId);
            builder.Property(t => t.RecipientId);

            builder.HasMany(op => op.OrderProducts).WithOne(o => o.Order);
        }
    }
}
