using PhoneStory.Domain.Entities;

namespace PhoneStore.Application.Cqrs.Events
{
    public abstract class ProductEvent : Event
    {
        public CellPhone Product { get; set; }
    }
}
