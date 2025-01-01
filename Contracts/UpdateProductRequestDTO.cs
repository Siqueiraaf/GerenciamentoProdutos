using System.ComponentModel.DataAnnotations;

namespace src.Contracts
{
    public class UpdateProductRequestDTO
    {
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set;} = string.Empty;
        [StringLength(50)]
        public string Category { get; set;} = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }
    }
}