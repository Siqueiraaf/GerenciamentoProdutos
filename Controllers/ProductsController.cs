using Microsoft.AspNetCore.Mvc;
using src.Services;
using src.Models;
using src.Contracts;
using src.Interfaces;

namespace src.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProduct productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter produtos: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var product = await _productService.GetByProductIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Produto não encontrado: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter produto: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        // POST: api/products
        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _productService.CreateProductAsync(request);
                return StatusCode(201);  // Retorna o código de status 201 (Created) após a criação.
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar produto: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequestDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _productService.UpdateProductAsync(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Produto não encontrado: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar produto: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Produto não encontrado: {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir produto: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
