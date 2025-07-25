using System.Collections.Generic;

namespace MyApi.Application.DTOs
{
    /// <summary>
    /// Representa o resultado de uma consulta paginada.
    /// </summary>
    /// <typeparam name="T">Tipo dos itens retornados.</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Itens da página atual.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Total de itens na consulta.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Página atual (1-based).
        /// </summary>
        public int Page { get; set; }
        
        /// <summary>
        /// Tamanho da página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Inicializa uma nova instância de PagedResult.
        /// </summary>
        /// <param name="data">Itens da página.</param>
        /// <param name="total">Total de itens.</param>
        /// <param name="page">Página atual.</param>
        /// <param name="pageSize">Tamanho da página.</param>
        public PagedResult(IEnumerable<T> data, int total, int page, int pageSize)
        {
            Data = data;
            Total = total;
            Page = page;
            PageSize = pageSize;
        }
    }
} 