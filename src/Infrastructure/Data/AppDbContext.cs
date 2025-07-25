using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Infrastructure.Data
{
    /// <summary>
    /// Contexto do banco de dados principal da aplicação, incluindo Identity e entidades de domínio.
    /// </summary>
    public class AppDbContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Inicializa uma nova instância de AppDbContext.
        /// </summary>
        /// <param name="options">Opções do contexto.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        /// <summary>
        /// Tabela de produtos.
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
} 