using Microsoft.AspNetCore.Identity;

namespace CRUDApplication.Domain.Entities
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
