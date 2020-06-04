using Client.Core.Integrations.Services.OrganisationApi.Models;
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
        public Guid? OfficeId { get; set; }
        public DateTime? SubmittedOnDate { get; set; }
        public DateTime? ApprovalDateTime { get; set; }
        public DateTime? ActivationDateTime { get; set; }
        public string Status { get; set; }
        public ClientAddressDto Address { get; set; }
        public ClientFamilyDetailsDto FamilyDetails { get; set; }
        public ClientContactDto Contact { get; set; }
        public string ClientType { get; set; }
        public StaffMemberDto StaffMember { get; set; }

        public ClientDto()
        {

        }

        public ClientDto(Entities.Client.PersonalClient entity) : base(entity)
        {
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            DateOfBirth = entity.DateOfBirth;
            PersonalId = entity.PersonalId;
            OfficeId = entity.OfficeId;
            SubmittedOnDate = entity.SubmittedOnDate;
            ApprovalDateTime = entity.ApprovalDateTime;
            ActivationDateTime = entity.ActivationDateTime;
            Status = entity.Status;
            Address = entity.ClientAddressData != null ? new ClientAddressDto(entity.ClientAddressData) : null;
            FamilyDetails = entity.ClientFamilyDetailsData != null ? new ClientFamilyDetailsDto(entity.ClientFamilyDetailsData) : null;
            Contact = entity.ClientContactData != null ? new ClientContactDto(entity.ClientContactData) : null;
            ClientType = entity.ClientType;
            StaffMember = entity.StaffMember != null ? new StaffMemberDto(entity.StaffMember) : null;
        }
    }
}
