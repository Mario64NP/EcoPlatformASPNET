using EcoPlatform.Models;

namespace EcoPlatform.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
