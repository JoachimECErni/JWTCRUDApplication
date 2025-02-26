using Microsoft.AspNetCore.Identity;

namespace CRUDApplication.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public IEnumerable<string> GetRoles()
        {
            return UserRoles.Select(ur => ur.Role.Name);
        }
    }
}
