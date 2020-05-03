using MicroBank.EventBus.Events;
using System;

namespace MicroBank.EventBus.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
