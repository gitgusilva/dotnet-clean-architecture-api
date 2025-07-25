namespace MyApi.Application.DTOs
{
    /// <summary>
    /// DTO para atualização de produto.
    /// </summary>
    public class UpdateProductDto
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public required string Name { get; set; }
        
        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Price { get; set; }
    }
} 