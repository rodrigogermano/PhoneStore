using PhoneStory.Domain.Entities;
using PhoneStory.Domain.Interfaces.Repositories;
using PhoneStory.Domain.Interfaces.Services;
using PhoneStory.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;

namespace PhoneStory.Domain.Services
{
    public class ProductService : IProductService
    {
        private IUow _uow;
        private IProductRepository _productRepository;        

        public ProductService(IUow uow, IProductRepository productRepository)
        {
            _uow = uow;
            _productRepository = productRepository;            
        }

        public void AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _productRepository.Create(product);
            _uow.Commit();
        }

        public Product GetProductById(Guid id)
        {
            return _productRepository.ReadById(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.ReadAll();
        }

        public void UpdateProduct(Product product)
        {            
            _productRepository.Update(product);
            _uow.Commit();
        }

        public void RemoveProductById(Guid id)
        {
            var product = GetProductById(id);
            
            _productRepository.Delete(id);
            var result = _uow.Commit();
        }
    }
}
