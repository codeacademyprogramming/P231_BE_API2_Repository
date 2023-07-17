using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Data;
using ShopApp.Api.Dtos.ProductDtos;
using ShopApp.Core.Entities;
using ShopApp.Core.Repositories;

namespace ShopApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductsController(IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        [HttpPost("")]
        public IActionResult Create(ProductCreateDto productDto)
        {
            if(!_brandRepository.IsExist(x=>x.Id == productDto.BrandId))
            {
                ModelState.AddModelError("BrandId", $"Brand not found by Id {productDto.BrandId}");
                return BadRequest(ModelState);
            }

            Product product = new Product
            {
                BrandId = productDto.BrandId,
                Name = productDto.Name,
                CostPrice = productDto.CostPrice,
                SalePrice = productDto.SalePrice,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4)
            };

            _productRepository.Add(product);
            _productRepository.Commit();

            return StatusCode(201, new {Id=product.Id});
        }

        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {
            Product product = _productRepository.Get(x=>x.Id ==id,"Brand");

            if (product == null) return NotFound();

            ProductGetDto productDto = new ProductGetDto
            {
                Name = product.Name,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Brand = new BrandInProductGetDto
                {
                    Id = product.BrandId,
                    Name = product.Brand.Name
                }
            };

            return Ok(productDto);
        }

        [HttpGet("all")]
        public ActionResult<List<ProductGetAllItemDto>> GetAll()
        {
            var productDtos = _productRepository.GetQueryable(x => true, "Brand").Select(x => 
            new ProductGetAllItemDto { Id = x.Id, Name = x.Name, BrandName = x.Brand.Name }).ToList();

            return Ok(productDtos);
        }
    }
}
