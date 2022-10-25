using Domain.Messages.Entities;
using Domain.Messages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Chats.Implementations
{
    public class MessageService : IMessageService
    {

        private readonly IMessageRepository _MessageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _MessageRepository = messageRepository;
        }

        public async Task addMessage(Message message)
        {
           await _MessageRepository.SaveAsync(message);
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(int room)
        {
            return await _MessageRepository.GetAllAsync(room);
        }
    }
}
