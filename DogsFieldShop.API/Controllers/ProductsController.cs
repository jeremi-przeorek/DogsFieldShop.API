using DogsFieldShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DogsFieldShop.Core.Interfaces;
using AutoMapper;
using DogsFieldShop.API.Dtos;
using DogsFieldShop.Core.Specyfications;

namespace DogsFieldShop.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductType> _typeRepository;
        private readonly IRepository<ProductBrand> _brandRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IRepository<Product> productRepository,
            IRepository<ProductType> typeRepository,
            IRepository<ProductBrand> brandRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _typeRepository = typeRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepository.GetAllWithSpecAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var product = await _productRepository.GetEntityWithSpecAsync(spec);

            return Ok(_mapper.Map<ProductDto>(product));
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