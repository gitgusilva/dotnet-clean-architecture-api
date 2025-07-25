namespace MyApi.Application.DTOs
{
    /// <summary>
    /// DTO para transferência de dados de produto.
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Price { get; set; }
    }
} 