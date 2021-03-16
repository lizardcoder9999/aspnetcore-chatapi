namespace ChatApi.Dtos
{
    public class RegisterDto
    {
        public string DisplayName { get; set; }

        public string ProfileUrl { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}