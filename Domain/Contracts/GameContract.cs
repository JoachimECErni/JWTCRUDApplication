using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Domain.Contracts
{
    public record CreateGame
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public double Price { get; set; }
        public short YearReleased { get; set; }
        public Guid CompanyId { get; set; }
    }
    public record UpdateGame
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public double Price { get; set; }
        public short YearReleased { get; set; }
        public Guid CompanyId { get; set; }
    }
    public record DeleteGame
    {
        public Guid Id { get; set; }

    }
    public record GetGame
    {
        public Guid Id { get; set; }

    }

    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public double Price { get; set; }
        public short YearReleased { get; set; }
        public Guid CompanyId { get; set; }
    }
}
