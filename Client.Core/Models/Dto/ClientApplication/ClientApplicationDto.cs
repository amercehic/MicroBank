using Client.Core.Models.Dto.ClientApplication;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Models.Dto
{
    public class ClientApplicationDto : BaseDto<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PersonalId { get; set; }
        public Guid OfficeId { get; set; }
        public bool Active { get; set; }
        public DateTime SubmittedOnDate { get; set; }
        public ClientApplicationAddressDto Address { get; set; }
        public ClientApplicationFamilyDetailsDto FamilyDetails { get; set; }
        public ClientApplicationContactDto Contact { get; set; }
        public string Status { get; set; }

        public ClientApplicationDto()
        {

        }

        public ClientApplicationDto(Entities.ClientApplication entity) : base(entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            DateOfBirth = entity.DateOfBirth;
            PersonalId = entity.PersonalId;
            OfficeId = entity.OfficeId;
            Active = entity.Active;
            SubmittedOnDate = entity.SubmittedOnDate;
            Address = entity.ClientApplicationAddressData != null ? new ClientApplicationAddressDto(entity.ClientApplicationAddressData) : null;
            FamilyDetails = entity.ClientApplicationFamilyDetailsData != null ? new ClientApplicationFamilyDetailsDto(entity.ClientApplicationFamilyDetailsData) : null;
            Contact = entity.ClientApplicationContactData != null ? new ClientApplicationContactDto(entity.ClientApplicationContactData) : null;
            Status = entity.Status;
        }
    }
}
