using PhoneStory.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PhoneStory.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Create(Product entity);
        IEnumerable<Product> ReadAll();
        Product ReadById(Guid id);
        void Update(Product entity);
        void Delete(Guid id);
    }
}
