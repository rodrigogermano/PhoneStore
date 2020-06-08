using PhoneStory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneStory.Domain.Interfaces.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void RemoveProductById(Guid id);
        void UpdateProduct(Product product);
    }
}
