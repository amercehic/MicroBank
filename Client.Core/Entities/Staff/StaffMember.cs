using MicroBank.Common.Models;
using System;

namespace Client.Core.Entities.Staff
{
    public class StaffMember : BaseEntity<Guid>
    {
        public Guid OfficeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoanOfficer { get; set; }
        public bool IsActive { get; set; }
    }
}
