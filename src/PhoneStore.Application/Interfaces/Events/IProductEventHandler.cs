using PhoneStore.Application.Cqrs.Events;

namespace PhoneStory.PhoneStore.Application.Interfaces.Events
{
    public interface IProductEventHandler
    {
        public void Handle(ProductAddedEvent domainEvent);

        public void Handle(ProductUpdatedEvent domainEvent);
        public void Handle(ProductDeletedEvent domainEvent);
    }
}
