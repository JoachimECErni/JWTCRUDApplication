namespace CRUDApplication.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public double Price {  get; set; }
        public short YearReleased { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
