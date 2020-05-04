using Client.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Core.Models.Dto
{
    public class ClientApplicationAddressDto
    {
        public string AddressLine { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }

        public ClientApplicationAddressDto()
        {

        }

        public ClientApplicationAddressDto(ClientApplicationAddressData entity)
        {
            AddressLine = entity.AddressLine;
            Street = entity.Street;
            Country = entity.Country;
            CountryCode = entity.CountryCode;
            Province = entity.Province;
        }
    }
}
