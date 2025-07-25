using MyApi.Application.DTOs;
using MyApi.Domain.Entities;
using MyApi.Domain.Interfaces;
using MyApi.Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Application.Services
{
    /// <summary>
    /// Serviço de aplicação para operações relacionadas a produtos.
    /// </summary>
    public class ProductService
    {
        private readonly IProductRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância de ProductService.
        /// </summary>
        /// <param name="repository">Repositório de produtos.</param>
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém uma lista paginada de produtos com filtro e ordenação.
        /// </summary>
        /// <param name="query">Parâmetros de consulta.</param>
        /// <returns>PagedResult de ProductDto.</returns>
        public async Task<PagedResult<ProductDto>> GetAllAsync(ProductQueryParameters query)
        {
            var products = _repository.Query();
            if (!string.IsNullOrWhiteSpace(query.Search))
                products = products.Where(p => p.Name.ToLower().Contains(query.Search.ToLower()));
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.ToLower() == "name")
                    products = query.Desc ? products.OrderByDescending(p => p.Name) : products.OrderBy(p => p.Name);
                else if (query.SortBy.ToLower() == "price")
                    products = query.Desc ? products.OrderByDescending(p => p.Price) : products.OrderBy(p => p.Price);
                else
                    products = products.OrderBy(p => p.Id);
            }
            else
            {
                products = products.OrderBy(p => p.Id);
            }
            var dtoQuery = products.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price });
            return await dtoQuery.Pagination(query.Page, query.PageSize);
        }

        /// <summary>
        /// Obtém um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>ProductDto ou null se não encontrado.</returns>
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            return p == null ? null : new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price };
        }

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        /// <param name="dto">DTO de criação de produto.</param>
        /// <returns>ProductDto criado.</returns>
        public async Task<ProductDto> AddAsync(CreateProductDto dto)
        {
            var product = new Product { Name = dto.Name, Price = dto.Price };
            var created = await _repository.AddAsync(product);
            return new ProductDto { Id = created.Id, Name = created.Name, Price = created.Price };
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="dto">DTO de atualização.</param>
        /// <returns>True se atualizado, false se não encontrado.</returns>
        public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;
            product.Name = dto.Name;
            product.Price = dto.Price;
            await _repository.UpdateAsync(product);
            return true;
        }
        
        /// <summary>
        /// Remove um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>True se removido, false se não encontrado.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;
            await _repository.DeleteAsync(product);
            return true;
        }
    }
} 