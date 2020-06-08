namespace PhoneStore.Application.Cqrs.Events
{
    public class ProductAddedEvent : ProductEvent
    {
        public const string EventQueueName = "product-added-event-queue";
        public override string QueueName => EventQueueName;
    }
}
