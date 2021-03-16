using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string SentBy { get; set; }

        public string messageSent { get; set; }

        public GroupChat GroupChat { get; set; }
        
        public int GroupChatId { get; set; }
        
    }
}