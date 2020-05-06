using Client.Core.Entities;

namespace Client.Core.Models.Dto.ClientApplication
{
    public class ClientApplicationContactDto
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public ClientApplicationContactDto()
        {

        }

        public ClientApplicationContactDto(ClientApplicationContactData entity)
        {
            EmailAddress = entity.EmailAddress;
            PhoneNumber = entity.PhoneNumber;
        }
    }
}
