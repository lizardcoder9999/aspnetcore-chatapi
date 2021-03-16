using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChatApi.Data.Repositories.Interfaces;
using ChatApi.Dtos;
using ChatApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("/api/v1/message")]
    public class MessageController : Controller
    {
        
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        
        public MessageController(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMessage(MessageDto messageDto)
        {
            await _messageRepository.AddMessage(messageDto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMessagesForChat([FromQuery] int id)
        {
            var messages = await _messageRepository.GetMessagesByGroupChat(id);
            var messagesToReturn = _mapper.Map<IReadOnlyList<Message>, IReadOnlyList<MessageDto>>(messages);
            return Ok(messagesToReturn);
        }
    }
}