using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApi.Data.Repositories.Interfaces;
using ChatApi.Dtos;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _context;
        
        public MessageRepository(ChatContext chatContext)
        {
            _context = chatContext;
        }
        
        public async Task AddMessage(MessageDto messageDto)
        {
            Message message = new Message();
            message.SentBy = messageDto.SentBy;
            message.messageSent = messageDto.messageSent;
            message.GroupChatId = messageDto.GroupChatId;
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Message>> GetMessagesByGroupChat(int id)
        {
            return await _context.Messages.Where(m => m.GroupChatId == id).ToListAsync();
        }
    }
}