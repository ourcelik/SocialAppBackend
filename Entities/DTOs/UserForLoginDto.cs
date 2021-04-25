using Core.Entities;

namespace Entities.DTOs
{
    public class UserForLoginDto :IDto
    {
        public string UserLoginInfo { get; set; }
        public string Password { get; set; }
    }
}
