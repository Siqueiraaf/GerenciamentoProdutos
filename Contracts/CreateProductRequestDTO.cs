using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Contracts
{
    public class CreateProductRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set;}

        [MaxLength(500)]
        public string Description { get; set;}

        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set;}
    }
}