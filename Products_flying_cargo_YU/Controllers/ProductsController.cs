using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Interface;
using Products_flying_cargo_YU.Models;
using Products_flying_cargo_YU.Service;

namespace Products_flying_cargo_YU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(ProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Products>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductsDto>>(_productsService.GetProducts());
            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Products>))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int productId)
        {
            var product = _productsService.GetProduct(productId);
            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductsDto>(product);
            return Ok(productDto);
        }

        [HttpGet("category/{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryByProduct(int productId)
        {
            var categories = _mapper.Map<List<CategoryDto>>(_productsService.GetCategoryByProduct(productId));
            return Ok(categories);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromQuery] int categoryId, [FromBody] ProductsDto productCreate)
        {
            if (productCreate == null)
                return BadRequest();

            var product = _mapper.Map<Products>(productCreate);

            try
            {
                _productsService.CreateProduct(categoryId, product);
                return Ok("Successfully created");
            }
            catch (Exception ex)
            {
                return StatusCode(422, new { error = ex.Message });
            }
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct(int productId, [FromQuery] int categoryId, [FromBody] ProductsDto productUpdate)
        {
            if (productUpdate == null || productId != productUpdate.ProductID)
                return BadRequest();

            var product = _mapper.Map<Products>(productUpdate);

            try
            {
                _productsService.UpdateProduct(categoryId, product);
                return Ok("Successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(422, new { error = ex.Message });
            }
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productsService.DeleteProduct(productId);
                return Ok("Successfully deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(422, new { error = ex.Message });
            }
        }
    }
}
