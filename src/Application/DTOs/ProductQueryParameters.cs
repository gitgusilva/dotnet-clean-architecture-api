namespace MyApi.Application.DTOs
{
    /// <summary>
    /// Parâmetros de consulta para paginação, filtro e ordenação de produtos.
    /// </summary>
    public class ProductQueryParameters
    {
        /// <summary>
        /// Página atual (1-based). Padrão: 1.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Tamanho da página. Padrão: 25.
        /// </summary>
        public int PageSize { get; set; } = 25;

        /// <summary>
        /// Texto de busca para filtrar pelo nome do produto.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Campo para ordenação (ex: "name", "price").
        /// </summary>
        public string? SortBy { get; set; }
        
        /// <summary>
        /// Se verdadeiro, ordena de forma decrescente.
        /// </summary>
        public bool Desc { get; set; } = false;
    }
} 