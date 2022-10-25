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
+-Summary: Component that handles repository of messages.
+*/

/* Project includes */
using Domain.Messages.Entities;

/* System includes */
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messages.Repositories
{
    public interface IMessageRepository 
    {
        Task SaveAsync(Message message);

        Task<IEnumerable<Message>> GetAllAsync(int roomId);

    }
}
