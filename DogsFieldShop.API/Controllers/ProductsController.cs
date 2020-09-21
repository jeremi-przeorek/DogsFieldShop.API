using DogsFieldShop.Infrastructure.Data;
using DogsFieldShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogsFieldShop.Core.Interfaces;
using System.Net.Http;

namespace DogsFieldShop.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRespository;

        public ProductsController(IProductRepository productRespository)
        {
            _productRespository = productRespository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRespository.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int id)
        {
            var product = await _productRespository.GetProductById(id);

            return Ok(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _productRespository.GetProductTypes());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> GetProductBrands()
        {
            return Ok(await _productRespository.GetProductBrands());
        }
    }
}
