using src.Contracts;
using src.Models;

namespace src.Utils
{
    public static class ProductMapper
    {
        public static ProductsManagement ToModel(CreateProductRequestDTO dto)
        {
            return new ProductsManagement
            {
                Id = Guid.NewGuid(),
                ProductName = dto.ProductName,
                Description = dto.Description,
                Category = dto.Category,
                Price = dto.Price,
                StockQuantity = 0,
                DueDate = DateTime.UtcNow.AddYears(1),
            };
        }

        public static ProductsManagement UpdateModel(ProductsManagement model, UpdateProductRequestDTO dto)
        {
            model.ProductName = dto.ProductName ?? model.ProductName;
            model.Description = dto.Description ?? model.Description;
            model.Category = dto.Category ?? model.Category;
            model.Price = dto.Price > 0 ? model.Price : model.Price;

            return model;
        }

        public static CreateProductRequestDTO ToCreateDTO(ProductsManagement model)
        {
            return new CreateProductRequestDTO
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
            };
        }

        public static UpdateProductRequestDTO ToUpdateDTO(ProductsManagement model)
        {
            return new UpdateProductRequestDTO
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
            };
        }
    }
}

/*

ToModel(CreateProductRequestDTO dto)
Converte um CreateProductRequestDTO para um objeto do modelo ProductsManagement, gerando automaticamente um novo Id.

UpdateModel(ProductsManagement model, UpdateProductRequestDTO dto)
Atualiza um objeto existente do tipo ProductsManagement com os dados fornecidos em um UpdateProductRequestDTO. Caso algum valor do DTO seja nulo ou inválido, mantém o valor existente.

ToCreateDTO(ProductsManagement model)
Converte um objeto do modelo ProductsManagement para o DTO CreateProductRequestDTO.

ToUpdateDTO(ProductsManagement model)
Converte um objeto do modelo ProductsManagement para o DTO UpdateProductRequestDTO.

*/

