using Client.Core.Entities.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Core.Models.Dto.Client
{
    public class ClientContactDto
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public ClientContactDto()
        {

        }

        public ClientContactDto(ClientContactData entity)
        {
            EmailAddress = entity.EmailAddress;
            PhoneNumber = entity.PhoneNumber;
        }
    }
}
