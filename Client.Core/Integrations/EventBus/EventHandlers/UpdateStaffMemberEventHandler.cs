using Client.Core.Exceptions.Client;
using Client.Core.Integrations.EventBus.Events;
using MicroBank.Common.Repository;
using MicroBank.EventBus.Bus;
using System;
using System.Threading.Tasks;

namespace Client.Core.Integrations.EventBus.EventHandlers
{
    public class UpdateStaffMemberEventHandler : IEventHandler<UpdateStaffMemberCreatedEvent>
    {
        private readonly IEfRepository<Entities.Staff.StaffMember, Guid> _efStaffMembertRepository;


        public UpdateStaffMemberEventHandler(
            IEfRepository<Entities.Staff.StaffMember, Guid> staffMembertRepository)
        {
            _efStaffMembertRepository = staffMembertRepository;
        }

        public async Task Handle(UpdateStaffMemberCreatedEvent @event)
        {
            var staffMember = await _efStaffMembertRepository.FindByAsync(
                 o => o.Id == @event.Id).ConfigureAwait(false);

            if (staffMember == null)
            {
                throw new ClientNotFoundException(id: @event.Id.ToString());
            }

            staffMember.IsLoanOfficer = @event.IsLoanOfficer;

            await _efStaffMembertRepository.UpdateAsync(staffMember).ConfigureAwait(false);
        }
    }
}
