using MicroBank.EventBus.Commands;
using System;

namespace Organisation.Core.Integrations.EventBus.Commands
{
    public class UpdateStaffMemberCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid ClientId { get; protected set; }
        public Guid OfficeId { get; set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string MobileNumber { get; protected set; }
        public bool IsLoanOfficer { get; protected set; }
        public bool IsActive { get; protected set; }
        public DateTime JoiningDate { get; set; }
    }
}
