using PhoneStore.Application.Cqrs.Commands;

namespace PhoneStore.Application.Interfaces.Handlers
{
    public interface IProductCommandHandler
    {
        public void Handle(AddProductCommand command);
        public void Handle(UpdateProductCommand command);
        public void Handle(DeleteProductCommand command);
    }
}
