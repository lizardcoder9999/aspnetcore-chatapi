using ChatApi.Models;

namespace ChatApi.Dtos
{
    public class MessageDto
    {
        public string SentBy { get; set; }

        public string messageSent { get; set; }

        public int GroupChatId { get; set; }
    }
}