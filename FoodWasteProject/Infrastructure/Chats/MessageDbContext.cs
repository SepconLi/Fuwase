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
+-Summary: Component that handles message.
+*/

using Domain.Messages.Entities;
using Infrastructure.Chats.EntityMappings;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Chats
{
    public class MessageDbContext : ApplicationDbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options, ILogger<MessageDbContext> logger) :  base(options, logger)
        {
        }

        public DbSet<Message> Messages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MessageMap());
        }

    }
}
