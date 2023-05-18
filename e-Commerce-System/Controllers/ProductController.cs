using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        public ProductController(IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IGenericRepository<Product> productRepo)
        {
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification(1);
            var products = await _productRepo.GetEntityWithSpec(spec);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return Ok(product);
            
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var ProductTypes = await _productTypeRepo.ListAllAsync(); 
            return Ok(ProductTypes);
        }
         
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var ProductBrands = await _productBrandRepo.ListAllAsync();
            return Ok(ProductBrands);
        }
    }
}
