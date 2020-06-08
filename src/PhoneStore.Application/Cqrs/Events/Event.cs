using System;

namespace PhoneStore.Application.Cqrs.Events
{
    public abstract class Event
    {
        public abstract string QueueName { get; }
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = new DateTime();
        }
    }
}
