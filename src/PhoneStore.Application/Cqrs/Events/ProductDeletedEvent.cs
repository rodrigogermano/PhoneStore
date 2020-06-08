namespace PhoneStore.Application.Cqrs.Events
{
    public class ProductDeletedEvent : ProductEvent
    {
        public const string EventQueueName = "product-deleted-event-queue";
        public override string QueueName => EventQueueName;
    }
}
