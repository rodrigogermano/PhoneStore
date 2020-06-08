using PhoneStory.Domain.Entities;

namespace PhoneStore.Application.Cqrs.Commands
{
    public abstract class ProductCommand : Command
    {
        public CellPhone Product { get; set; }
    }
}
