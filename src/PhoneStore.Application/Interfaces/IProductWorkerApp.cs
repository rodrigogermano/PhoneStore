using PhoneStore.Application.Cqrs.Commands;

namespace PhoneStore.Application.Interfaces
{
    public interface IProductWorkerApp
    {
        void AddProduct(AddProductCommand command);
        void UpdateProduct(UpdateProductCommand command);
        void DeleteProduct(DeleteProductCommand command);
    }
}
