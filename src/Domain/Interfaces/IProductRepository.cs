using MyApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MyApi.Domain.Interfaces
{
    /// <summary>
    /// Interface para operações de acesso a dados de produtos.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Obtém um produto pelo ID.
        /// </summary>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Adiciona um novo produto.
        /// </summary>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Remove um produto.
        /// </summary>
        Task DeleteAsync(Product product);
        
        /// <summary>
        /// Retorna um IQueryable para consultas customizadas.
        /// </summary>
        IQueryable<Product> Query();
    }
} 