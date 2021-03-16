using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Data.Repositories.Interfaces
{
    public interface IGroupChatRepository
    {
        Task<GroupChat> createGroupChat(GroupChat groupChat);
        Task<IReadOnlyList<GroupChat>> GetAllGroupChats();
    }
}