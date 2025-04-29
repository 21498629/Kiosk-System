using Kiosk.Models.User;

namespace Kiosk.Models
{
    public interface ITokenService
    {
        string CreateToken(Users user);
    }
}
