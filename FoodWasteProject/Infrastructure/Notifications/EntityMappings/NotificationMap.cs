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
+-Summary: Component that makes the Noticatios.
+*/


/* Project includes */

using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Notifications.Entities;
using Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Notifications.EntityMappings
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {  // Mapping to table Notification
            builder.ToTable("Notification");
            // Mapping attribute id
            builder.HasKey(t => t.Id);
            // Mapping attribute email
            builder.Property(t => t.Email);
            // Mapping attribute NotificationText
            builder.Property(t => t.NotificationText);
            // Mapping attribute Link
            builder.Property(t => t.Link);
            // Mapping attribute ReadNotification
            builder.Property(t => t.ReadNotification);
            // Mapping attribute TimeNotification
            builder.Property(t => t.TimeNotification);


        }
    }
}
