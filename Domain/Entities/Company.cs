using CRUDApplication.Common;
using CRUDApplication.Converter;
using Newtonsoft.Json;

namespace CRUDApplication.Domain.Entities
{
    public class Company
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(CountryOfOriginConverter))]
        public countryOfOrigin CountryOfOrigin { get; set; }
        public ICollection<Game> Games { get; set; }
        public int EmployeeCount { get; set; }
    }
}
