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
using Domain.Notifications.Entities;
using Infrastructure.Notifications.EntityMappings;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Notifications
{
    public class NotificationDbContext : ApplicationDbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options, ILogger<NotificationDbContext> logger) : base(options, logger)
        {
        }

        public DbSet<Notification> Notifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NotificationMap());
        }
    }
}
