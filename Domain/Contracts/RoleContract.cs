namespace CRUDApplication.Domain.Entities
{
    public class CreateRole
    {
        public string Name { get; set; }
    }

    public class UpdateRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
