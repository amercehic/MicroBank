using MicroBank.EventBus.Commands;
using MicroBank.EventBus.Events;
using System.Threading.Tasks;

namespace MicroBank.EventBus.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;
        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
