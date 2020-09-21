using DogsFieldShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogsFieldShop.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IReadOnlyList<Product>> GetProducts();

        Task<IReadOnlyList<ProductType>> GetProductTypes();

        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
    }
}
