using MicroBank.EventBus.Events;
using System;

namespace Organisation.Core.Integrations.EventBus.Events
{
    public class UpdateStaffMemberCreatedEvent : Event
    {
        public Guid Id { get; protected set; }
        public bool IsLoanOfficer { get; protected set; }

        public UpdateStaffMemberCreatedEvent(Guid id, bool isLoanOfficer)
        {
            Id = id;
            IsLoanOfficer = isLoanOfficer;
        }
    }
}
