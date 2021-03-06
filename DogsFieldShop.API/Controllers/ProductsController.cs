﻿using DogsFieldShop.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DogsFieldShop.Core.Interfaces;
using AutoMapper;
using DogsFieldShop.API.Dtos;
using DogsFieldShop.Core.Specyfications;
using DogsFieldShop.API.Controllers;
using DogsFieldShop.API.Errors;
using Microsoft.AspNetCore.Http;
using DogsFieldShop.API.Helpers;

namespace DogsFieldShop.Infrastructure.Controllers
{
    public class ProductsController : BaseApiController
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
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(
            [FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);
            var specForCount = new ProductsWithFiltersForCountSpecification(productSpecParams);

            var products = await _productRepository.GetAllWithSpecAsync(spec);
            var count = await _productRepository.CountAsync(specForCount);

            return Ok(new Pagination<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize, count, _mapper.Map<IReadOnlyList<ProductDto>>(products)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetProducts(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpecAsync(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            return Ok(await _typeRepository.GetAll());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _brandRepository.GetAll());
        }
    }
}