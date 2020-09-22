using DogsFieldShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DogsFieldShop.Core.Interfaces;

namespace DogsFieldShop.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _typeRepository;
        private readonly IRepository<ProductBrand> _brandRepository;

        public ProductsController(
            IRepository<Product> productRepository,
            IRepository<ProductType> typeRepository,
            IRepository<ProductBrand> brandRepository)
        {
            _productRepository = productRepository;
            _typeRepository = typeRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int id)
        {
            return Ok(await _productRepository.GetById(id));
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _typeRepository.GetAll());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductType>>> GetProductBrands()
        {
            return Ok(await _brandRepository.GetAll());
        }
    }
}
