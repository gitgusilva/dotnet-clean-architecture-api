using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;
using MyApi.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MyApi.Infrastructure.Data;

namespace MyApi.Infrastructure.Repositories
{
    /// <summary>
    /// Implementação do repositório de produtos usando Entity Framework Core.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância de ProductRepository.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        
        /// <inheritdoc/>
        public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
        
        /// <inheritdoc/>
        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        
        /// <inheritdoc/>
        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
        /// <inheritdoc/>
        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        
        /// <inheritdoc/>
        public IQueryable<Product> Query() => _context.Products.AsQueryable();
    }
} 