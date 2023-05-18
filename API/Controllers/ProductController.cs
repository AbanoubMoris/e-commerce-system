using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository,IMapper mapper,
            IGenericRepository<ProductBrand> productBrandRepo,IGenericRepository<ProductType> productTypeRepo, IGenericRepository<Product> productRepo)
        {
            _productRepository = productRepository;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }
        /*
        [HttpGet("")]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            var spec = new ProducctWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDTO>>(products);
        }
        */
        [HttpGet()]
        public async Task<List<ProductDTO>> GetProducts()
        {
            var spec = new ProducctWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAsync(spec);
            return _mapper.Map<IReadOnlyList<Product>, List<ProductDTO>>(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProducctWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            
            return _mapper.Map<Product, ProductDTO>(product);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
    }
}
