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
+-Summary: Component that handles interphase of MessageService.
+*/

using Domain.Messages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chats
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetMessagesAsync(int room);

        Task addMessage(Message message);
    }
}
