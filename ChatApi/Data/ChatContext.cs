using ChatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
            
        }

        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}