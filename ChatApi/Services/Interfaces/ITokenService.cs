using ChatApi.Models;

namespace ChatApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}