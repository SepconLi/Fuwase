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
+-Summary: Component that handles map.
+*/

using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Messages.Entities;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Chats.EntityMappings
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Date_Message);

            builder.Property(t => t.Text);

            builder.Property(t => t.SenderId);

            builder.Property(t => t.OrderId);
            
            
        }
    }
}
