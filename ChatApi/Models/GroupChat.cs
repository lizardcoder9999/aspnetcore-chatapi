using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class GroupChat
    {
        [Key]
        public int GroupChatId { get; set; }

        public string GroupChatName { get; set; }
    }
}