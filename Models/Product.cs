namespace src.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string ProductName { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime DueDate { get; set; }

    }
}