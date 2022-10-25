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
+-Summary: Component for chat.
+*/

/* Project includes */
using Microsoft.AspNetCore.SignalR;

/* System includes */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chats
{
    public class ChatHub : Hub //Preguntarle al profe por la interface
    {
        /**  Attributes **/

        // Basic attributes
        public const string HubUrl = "/chat";

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
        public async Task JoinGroup(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);

            await base.OnConnectedAsync();
        }

        public async Task SendMessageToGroup(string room, string user, string message)
        {
            await Clients.Group(room).SendAsync("Broadcast", user, message);
        }
    }
}
