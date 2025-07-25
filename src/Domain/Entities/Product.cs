namespace MyApi.Domain.Entities
{
    /// <summary>
    /// Entidade que representa um produto.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int Id { get; set; }

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