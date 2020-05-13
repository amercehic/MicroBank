using MediatR;
using MicroBank.EventBus.Bus;
using Organisation.Core.Integrations.EventBus.Commands;
using Organisation.Core.Integrations.EventBus.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Organisation.Core.Integrations.EventBus.CommandHandlers
{
    public class UpdateStaffMemberCommandHandler : IRequestHandler<CreateUpdateStaffMemberCommand, bool>
    {
        private readonly IEventBus _bus;

        public UpdateStaffMemberCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateUpdateStaffMemberCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new UpdateStaffMemberCreatedEvent(request.Id, request.IsLoanOfficer));

            return Task.FromResult(true);
        }
    }
}
