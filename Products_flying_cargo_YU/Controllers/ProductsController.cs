using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products_flying_cargo_YU.Dto;
using Products_flying_cargo_YU.Interface;
using Products_flying_cargo_YU.Models;

namespace Products_flying_cargo_YU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Products>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductsDto>>(_productsRepository.GetProducts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Products>))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int productId)
        {
            if (!_productsRepository.ProductExists(productId))
                return NotFound();

            var product = _mapper.Map<ProductsDto>(_productsRepository.GetProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        [HttpGet("category/{productId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryByProduct(int productId)
        {
            var category = _mapper.Map<List<CategoryDto>>(_productsRepository.GetCategoryByProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromQuery] int categoryId, [FromBody] ProductsDto productCreate)
        {
            if (productCreate == null)
                return BadRequest(ModelState);

            var products = _productsRepository.GetProducts()
                .Where(p => p.ProductName.Trim().ToUpper() == productCreate.ProductName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (products != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productMap = _mapper.Map<Products>(productCreate);

            if (!_productsRepository.CreateProduct(categoryId, productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct(int productId, [FromQuery] int categoryId, [FromBody] ProductsDto productUpdate)
        {
            if (productUpdate == null)
                return BadRequest(ModelState);

            if (productId != productUpdate.ProductID)
                return BadRequest(ModelState);

            if (!_productsRepository.ProductExists(productId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productMap = _mapper.Map<Products>(productUpdate);

            if (!_productsRepository.UpdateProduct(categoryId, productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct(int productId)
        {
            if (!_productsRepository.ProductExists(productId))
                return NotFound();

            var productCategoryToDelete = _productsRepository.GetCategoryByProduct(productId);
            var productToDelete = _productsRepository.GetProduct(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_productsRepository.DeleteProduct(productToDelete))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
