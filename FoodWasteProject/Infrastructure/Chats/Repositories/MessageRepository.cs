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
+-Summary: Repository of messages.
+*/

/* Project includes */
using Domain.Core.Repositories;

/* System includes */
using Domain.Messages.Entities;
using Domain.Messages.Repositories;
using Infrastructure.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Chats.Repositories
{
    internal class MessageRepository : IMessageRepository
    {
        /**  Attributes **/

        // Basic attributes
        private readonly MessageDbContext _dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public MessageRepository(MessageDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task SaveAsync(Message message)
        {
            _dbContext.Messages.Add(message);
            Console.WriteLine("Guardado");
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<Message>> GetAllAsync(int roomId)
        {
            return await _dbContext.Messages.Where(d => d.OrderId == roomId).
                Select(t => new  Message(t.Id,t.Date_Message,t.Text, t.SenderId, t.OrderId)).
                ToListAsync();
        }
    }
}
