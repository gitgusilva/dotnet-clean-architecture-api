using Microsoft.AspNetCore.Mvc;
using MyApi.Application.DTOs;
using MyApi.Application.Services;

namespace MyApi.Presentation.Controllers
{
    /// <summary>
    /// Controller para operações CRUD de produtos.
    /// </summary>
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        /// <summary>
        /// Inicializa uma nova instância de ProductsController.
        /// </summary>
        /// <param name="service">Serviço de produtos.</param>
        public ProductsController(ProductService service)
        {
            _service = service;
        }
        /// <summary>
        /// Lista produtos com paginação, filtro e ordenação.
        /// </summary>
        /// <param name="query">Parâmetros de consulta.</param>
        /// <returns>PagedResult de ProductDto.</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductDto>>> GetProducts([FromQuery] ProductQueryParameters query)
        {
            var result = await _service.GetAllAsync(query);
            return Ok(result);
        }
        /// <summary>
        /// Obtém um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>ProductDto ou 404 se não encontrado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="dto">DTO de criação.</param>
        /// <returns>ProductDto criado.</returns>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
        }
        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="dto">DTO de atualização.</param>
        /// <returns>NoContent se atualizado, 404 se não encontrado.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Remove um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>NoContent se removido, 404 se não encontrado.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Retorna o usuário autenticado extraído do JWT.
        /// </summary>
        /// <returns>Nome do usuário autenticado.</returns>
        [HttpGet("me")]
        public ActionResult<object> GetMe()
        {
            var username = User.Identity?.Name ?? "(desconhecido)";
            return Ok(new { user = username });
        }
    }
} 