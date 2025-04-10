using Kiosk.Models.User;

namespace Kiosk.View_Models
{
    public interface ITokenService
    {
        string CreateToken(Users user);
    }
}
