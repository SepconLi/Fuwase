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
using Microsoft.AspNetCore.SignalR.Client;
/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chats
{
    public interface IChatService
    {
        Task DisconnectAsync(HubConnection _hubConnection);

        Task SendAsync(string message, string _username, HubConnection _hubConnection);

        Task SendAsyncToGroup(string room, string message, string _username, HubConnection _hubConnection);

        Task AddToGroupAsync(string room, HubConnection _hubConnection);

    }
}
