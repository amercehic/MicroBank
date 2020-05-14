using Client.Core.Integrations.Services.OfficeApi.Models;
using MicroBank.Common.Models;
using System;

namespace Client.Core.Integrations.Services.OrganisationApi.Models
{
    public class StaffMemberDto : BaseDto<Guid>
    {
        public OfficeDto Office { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoanOfficer { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
