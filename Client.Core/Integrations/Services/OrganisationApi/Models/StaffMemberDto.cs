using Client.Core.Integrations.Services.OfficeApi.Models;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Integrations.Services.OrganisationApi.Models
{
    public class StaffMemberDto : BaseDto<Guid>
    {
        public Guid? OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoanOfficer { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }

        public StaffMemberDto()
        {

        }

        public StaffMemberDto(Entities.Staff.StaffMember entity) : base(entity)
        {
            OfficeId = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            IsLoanOfficer = entity.IsLoanOfficer;
            IsActive = entity.IsActive;
        }
    }
}
