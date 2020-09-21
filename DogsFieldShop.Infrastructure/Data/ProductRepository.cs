using DogsFieldShop.Core.Entities;
using DogsFieldShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DogsFieldShop.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _storeContext.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _storeContext.Products.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}
