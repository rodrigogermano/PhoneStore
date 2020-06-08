namespace PhoneStore.Application.Cqrs.Events
{
    public class ProductUpdatedEvent : ProductEvent
    {
        public const string EventQueueName = "product-updated-event-queue";
        public override string QueueName => EventQueueName;
    }
}
