using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Contracts
{
    public class UpdateProductRequestDTO
    {
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string Description { get; set;}

        [StringLength(50)]
        public string Category { get; set;}
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }
    }
}