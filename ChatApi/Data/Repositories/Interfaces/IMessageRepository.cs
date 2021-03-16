using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Dtos;
using ChatApi.Models;

namespace ChatApi.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task AddMessage(MessageDto messageDto);
        Task<IReadOnlyList<Message>> GetMessagesByGroupChat(int id);
    }
}