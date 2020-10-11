using DogsFieldShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogsFieldShop.Core.Specyfications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecyfication<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
        : base(x =>
            (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
            && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {

        }

    }
}
