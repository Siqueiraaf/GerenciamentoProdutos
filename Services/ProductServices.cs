using Microsoft.EntityFrameworkCore;
using src.Contracts;
using src.Data;
using src.Interfaces;
using src.Models;
using src.Utils;

namespace src.Services
{
    public class ProductServices : IProduct
    {
        // Injecao de dependencia
        private readonly ProductDbContext _context;
        private readonly ILogger<ProductServices> _logger;

        public ProductServices(ProductDbContext context, ILogger<ProductServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Buscar todos os produtos
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao buscar os produtos: {ex.Message}");
                throw;
            }
        }

        // Criar um novo produto
        public async Task CreateProductAsync(CreateProductRequestDTO requestDTO)
        {
            try
            {
                // Criar o produto
                var product = ProductMapper.ToModel(requestDTO);
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logar o erro
                _logger.LogError($"Ocorreu um erro ao criar o produto: {ex.Message}");
                throw;
            }
        }
        
        // Atualizar um produto
        public async Task UpdateProductAsync(Guid id, UpdateProductRequestDTO requestDTO)
        {
            
            try
            {
                // Verificar se o produto existe
                var existingProduct = await _context.Products.FindAsync(id);

                if (existingProduct == null)
                {
                    _logger.LogWarning($"Produto com ID {id} não encontrado.");
                    throw new KeyNotFoundException("Produto não encontrado.");
                }

                // Atualizar o produto
                ProductMapper.UpdateModel(existingProduct, requestDTO);
                _context.Products.Update(existingProduct);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logar o erro
                _logger.LogError($"Ocorreu um erro ao atualizar o produto: {ex.Message}");
                throw;
            }
        }

        // Deletar um produto
        public async Task DeleteProductAsync(Guid id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    _logger.LogWarning($"Produto com ID {id} não encontrado.");
                    throw new KeyNotFoundException("Produto nao encontrado.");
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar produto.");
                throw;
            }
        }

        // Busca um produto pelo ID
        public async Task<Product> GetByProductIdAsync(Guid id)
        {
            // Aguarda o resultado do FindAsync
            var product = await _context.Products.FindAsync(id);

            // Verifica se o produto foi encontrado
            if (product == null)
            {
                _logger.LogWarning($"Produto com ID {id} não encontrado.");
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            return product;
        }
    }
}