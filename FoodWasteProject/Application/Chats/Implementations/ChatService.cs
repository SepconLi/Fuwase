using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Messages.Entities;


using Microsoft.AspNetCore.SignalR.Client;


namespace Application.Chats.Implementations
{
    internal class ChatService : IChatService
    {
        public async Task DisconnectAsync(HubConnection _hubConnection)
        {
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
        }

        public async Task SendAsync(string message, string _username, HubConnection _hubConnection)
        {
            await _hubConnection.SendAsync("Broadcast", _username, message);
        }

        public async Task SendAsyncToGroup(string room, string message, string _username, HubConnection _hubConnection)
        {
            await _hubConnection.SendAsync("SendMessageToGroup", room, _username, message);
        }
        public async Task AddToGroupAsync(string room, HubConnection _hubConnection)
        {
            await _hubConnection.SendAsync("JoinGroup", room);

        }

    }
}
