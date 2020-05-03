using MicroBank.EventBus.Events;
using System.Threading.Tasks;

namespace MicroBank.EventBus.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
