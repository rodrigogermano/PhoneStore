using PhoneStore.Application.Cqrs.Commands;
using PhoneStore.Application.Cqrs.Events;
using PhoneStore.Application.Interfaces.Handlers;
using PhoneStory.Domain.Interfaces.Mediator;
using PhoneStory.Domain.Interfaces.Services;
using PhoneStory.Domain.Services;

namespace PhoneStore.Application.Cqrs.CommandHandlers
{
    public class ProductCommandHandler : IProductCommandHandler
    {
        private IProductService _productService;
        private readonly IMediatorHandler _bus;

        public ProductCommandHandler(IProductService productService, IMediatorHandler bus)
        {
            _productService = productService;
            _bus = bus;
        }

        public void Handle(AddProductCommand command)
        {            
            _productService.AddProduct(command.Product);

            _bus.Enqueue<ProductAddedEvent>(new ProductAddedEvent { Product = command.Product }, ProductAddedEvent.EventQueueName);
        }

        public void Handle(UpdateProductCommand command)
        {
            _productService.UpdateProduct(command.Product);

            _bus.Enqueue<ProductUpdatedEvent>(new ProductUpdatedEvent { Product = command.Product }, ProductUpdatedEvent.EventQueueName);
        }

        public void Handle(DeleteProductCommand command)
        {
            _productService.RemoveProductById(command.Product.Id);

            _bus.Enqueue<ProductDeletedEvent>(new ProductDeletedEvent { Product = command.Product }, ProductDeletedEvent.EventQueueName);
        }
    }
}
