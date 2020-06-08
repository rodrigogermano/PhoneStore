using PhoneStore.Application.Cqrs.Commands;
using PhoneStore.Application.Interfaces;
using PhoneStore.Application.Interfaces.Handlers;

namespace PhoneStore.Application.Services
{
    public class ProductWorkerApp : IProductWorkerApp
    {
        private readonly IProductCommandHandler _productCommandHandler;

        public ProductWorkerApp(IProductCommandHandler productCommandHandler)
        {
            _productCommandHandler = productCommandHandler;
        }

        public void AddProduct(AddProductCommand command)
        {
            _productCommandHandler.Handle(command);
        }

        public void UpdateProduct(UpdateProductCommand command)
        {
            _productCommandHandler.Handle(command);
        }

        public void DeleteProduct(DeleteProductCommand command)
        {
            _productCommandHandler.Handle(command);
        }
    }
}

