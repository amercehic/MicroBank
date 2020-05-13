using MicroBank.EventBus.Events;
using System;

namespace Client.Core.Integrations.EventBus.Events
{
    public class UpdateStaffMemberCreatedEvent : Event
    {
        public Guid Id { get; private set; }
        public bool IsLoanOfficer { get; private set; }

        public UpdateStaffMemberCreatedEvent(Guid id, bool isLoanOfficer)
        {
            Id = id;
            IsLoanOfficer = isLoanOfficer;
        }
    }
}
