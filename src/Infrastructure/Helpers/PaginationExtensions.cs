using Microsoft.EntityFrameworkCore;
using MyApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Infrastructure.Helpers
{
    /// <summary>
    /// Métodos de extensão para paginação de consultas IQueryable.
    /// </summary>
    public static class PaginationExtensions
    {
        /// <summary>
        /// Aplica paginação a uma consulta IQueryable e retorna um PagedResult.
        /// </summary>
        /// <typeparam name="T">Tipo da entidade.</typeparam>
        /// <param name="query">Consulta IQueryable.</param>
        /// <param name="page">Número da página (1-based). Se menor que 1, será considerado 1.</param>
        /// <param name="pageSize">Tamanho da página. Se menor que 1, será considerado 25.</param>
        /// <returns>PagedResult contendo os dados paginados, total, página e pageSize.</returns>
        public static async Task<PagedResult<T>> Pagination<T>(
            this IQueryable<T> query, int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 25;
            
            var total = await query.CountAsync();
            var data = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            
            return new PagedResult<T>(data, total, page, pageSize);
        }
    }
} 