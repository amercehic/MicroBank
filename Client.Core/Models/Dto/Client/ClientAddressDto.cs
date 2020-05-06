using Client.Core.Entities.Client;

namespace Client.Core.Models.Dto.Client
{
    public class ClientAddressDto
    {
        public string AddressLine { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }

        public ClientAddressDto()
        {

        }

        public ClientAddressDto(ClientAddressData entity)
        {
            AddressLine = entity.AddressLine;
            Street = entity.Street;
            Country = entity.Country;
            CountryCode = entity.CountryCode;
            Province = entity.Province;
        }
    }
}
