using MicroBank.Common.Models;
using Organisation.Core.Entities;
using System;
using System.Linq;


namespace Organisation.Core.Models.Dto
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

        public StaffMemberDto()
        {

        }

        public StaffMemberDto(StaffMember entity) : base(entity)
        {
            Office = entity.Office != null ? new OfficeDto(entity.Office) : null;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            IsLoanOfficer = entity.IsLoanOfficer;
            MobileNumber = entity.MobileNumber;
            IsActive = entity.IsActive;
            JoiningDate = entity.JoiningDate;
        }
    }
}
