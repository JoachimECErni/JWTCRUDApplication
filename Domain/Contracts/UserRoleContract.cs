namespace CRUDApplication.Domain.Entities
{
    public class CreateUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class UpdateUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
