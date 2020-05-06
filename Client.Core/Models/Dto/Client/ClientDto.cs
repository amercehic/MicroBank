using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Dto.Client
{
    public class ClientDto : BaseDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public bool Active { get; set; }
        public DateTime SubmittedOnDate { get; set; }
        public ClientAddressDto Address { get; set; }
        public ClientFamilyDetailsDto FamilyDetails { get; set; }
        public ClientContactDto Contact { get; set; }
        public ClientApplicationDto ClientApplication { get; set; }

        public ClientDto()
        {

        }

        public ClientDto(Entities.Client.Client entity) : base(entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            DateOfBirth = entity.DateOfBirth;
            PersonalId = entity.PersonalId;
            OfficeId = entity.OfficeId;
            Active = entity.Active;
            SubmittedOnDate = entity.SubmittedOnDate;
            Address = entity.ClientAddressData != null ? new ClientAddressDto(entity.ClientAddressData) : null;
            FamilyDetails = entity.ClientFamilyDetailsData != null ? new ClientFamilyDetailsDto(entity.ClientFamilyDetailsData) : null;
            Contact = entity.ClientContactData != null ? new ClientContactDto(entity.ClientContactData) : null;
            ClientApplication = entity.ClientApplication != null ? new ClientApplicationDto(entity.ClientApplication) : null;
        }
    }
}
