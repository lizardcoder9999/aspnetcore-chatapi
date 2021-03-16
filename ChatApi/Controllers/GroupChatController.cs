using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApi.Data.Repositories.Interfaces;
using ChatApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("/api/v1/chat")]
    public class GroupChatController : Controller
    {

        private readonly IGroupChatRepository _chatRepository;
        
        public GroupChatController(IGroupChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateChat(GroupChat chat)
        {
            return Ok(await _chatRepository.createGroupChat(chat));
        }

        [HttpGet]
        public async Task<IReadOnlyList<GroupChat>> GetAllChats()
        {
            return await _chatRepository.GetAllGroupChats();
        }
    }
}