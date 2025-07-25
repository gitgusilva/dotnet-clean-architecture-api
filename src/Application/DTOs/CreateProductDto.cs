namespace MyApi.Application.DTOs
{
    /// <summary>
    /// DTO para criação de produto.
    /// </summary>
    public class CreateProductDto
    {
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