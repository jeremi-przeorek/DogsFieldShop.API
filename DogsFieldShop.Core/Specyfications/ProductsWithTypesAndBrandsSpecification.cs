using DogsFieldShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DogsFieldShop.Core.Specyfications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecyfication<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductsWithTypesAndBrandsSpecification
            (int price) : base(x => x.Price > price)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
