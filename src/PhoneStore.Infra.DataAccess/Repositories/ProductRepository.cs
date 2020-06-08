using PhoneStore.Infra.DataAccess.Contexts;
using PhoneStory.Domain.Entities;
using PhoneStory.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneStore.Infra.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private PhoneStoreContext _context;

        public ProductRepository(PhoneStoreContext context)
        {
            _context = context;
        }
        public void Create(Product entity)
        {
            this._context.Products.Add(entity);
        }

        public void Delete(Guid id)
        {
            var _product = this._context.Products.FirstOrDefault(x => x.Id == id);

            if (!(_product is null))
                this._context.Products.Remove(_product);
        }

        public IEnumerable<Product> ReadAll()
        {
            return this._context.Products.ToList();
        }

        public Product ReadById(Guid id)
        {
            return this._context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product entity)
        {
            this._context.Products.Update(entity);
        }
    }
}
