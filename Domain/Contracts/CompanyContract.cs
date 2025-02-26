using CRUDApplication.Common;
using CRUDApplication.Domain.Entities;

namespace CRUDApplication.Domain.Contracts
{
    public record CreateCompany
    {
        public string Name { get; set; }
        public countryOfOrigin CountryOfOrigin { get; set; }
        public int EmployeeCount { get; set; }

    }

    public record UpdateCompany
    {
        public string Name { get; set; }
        public countryOfOrigin CountryOfOrigin { get; set; }
    }

    public record DeleteCompany
    {
        public Guid Id { get; set; }
    }

    public record GetCompany
    {
        public Guid Id { get; set; }
    }

    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public countryOfOrigin CountryOfOrigin { get; set; }
        public ICollection<GameDto> Games { get; set; }
    }


}
