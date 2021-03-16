using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Data.Repositories.Interfaces;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data.Repositories
{
    public class GroupChatRepository : IGroupChatRepository
    {

        private readonly ChatContext _context;
        
        public GroupChatRepository(ChatContext context)
        {
            _context = context;
        }
        
        public async Task<GroupChat> createGroupChat(GroupChat groupChat)
        {
            await _context.GroupChats.AddAsync(groupChat);
            await _context.SaveChangesAsync();

            return groupChat;
        }

        public async Task<IReadOnlyList<GroupChat>> GetAllGroupChats()
        {
             return await _context.GroupChats.ToListAsync();
        }
    }
}