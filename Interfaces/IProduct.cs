using src.Contracts;
using src.Models;

namespace src.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetByProductIdAsync(Guid id);
        Task CreateProductAsync(CreateProductRequestDTO requestDTO);
        Task UpdateProductAsync(Guid id, UpdateProductRequestDTO requestDTO);
        Task DeleteProductAsync(Guid id);
    }
}