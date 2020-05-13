using System;

namespace Organisation.Core.Integrations.EventBus.Commands
{
    public class CreateUpdateStaffMemberCommand : UpdateStaffMemberCommand
    {
        public CreateUpdateStaffMemberCommand(Guid id, bool isLoanOfficer)
        {
            Id = id;
            IsLoanOfficer = isLoanOfficer;
        }
    }
}
