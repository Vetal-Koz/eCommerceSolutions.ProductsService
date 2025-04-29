using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ProductResponse>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("search/product-id/{productId}")]
        public async Task<ActionResult<ProductResponse>> GetProductsByProductId([FromQuery] Guid productId)
        {
            var product = await _productService.GetProductById(productId);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }

        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductsByCondition([FromQuery] string searchString)
        {
            var products = await _productService.GetProductsByCondition(searchString);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddRequest productAddRequest)
        {
            if (productAddRequest == null)
            {
                return BadRequest("Ivallid product add request");
            }
            var product = await _productService.AddProduct(productAddRequest);
            return StatusCode(201, product);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct([FromQuery] Guid productId ,[FromBody] ProductUpdateRequest productUpdateRequest)
        {
            if (productUpdateRequest == null)
            {
                return BadRequest("Invalid product add request");                
            }
            
            var product = await _productService.UpdateProduct(productId, productUpdateRequest);
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromQuery] Guid productId)
        {
            await _productService.DeleteProduct(productId);
            return Ok();
        }
        
    }
}
