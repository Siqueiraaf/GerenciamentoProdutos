using src.Contracts;
using src.Models;

namespace src.Utils
{
    public static class ProductMapper
    {
        public static Product ToModel(CreateProductRequestDTO requestDTO)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                ProductName = requestDTO.ProductName,
                Description = requestDTO.Description,
                Category = requestDTO.Category,
                Price = requestDTO.Price,
                StockQuantity = 0,
                DueDate = DateTime.UtcNow.AddYears(1),
            };
        }

        public static Product UpdateModel(Product model, UpdateProductRequestDTO requestDTO)
        {
            model.ProductName = requestDTO.ProductName ?? model.ProductName;
            model.Description = requestDTO.Description ?? model.Description;
            model.Category = requestDTO.Category ?? model.Category;
            model.Price = requestDTO.Price > 0 ? model.Price : model.Price;

            return model;
        }

        public static CreateProductRequestDTO ToCreateDTO(Product model)
        {
            return new CreateProductRequestDTO
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
            };
        }

        public static UpdateProductRequestDTO ToUpdateDTO(Product model)
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

ToModel(CreateProductRequestDTO requestDTO)
Converte um CreateProductRequestDTO para um objeto do modelo ProductsManagement, gerando automaticamente um novo Id.

UpdateModel(ProductsManagement model, UpdateProductRequestDTO requestDTO)
Atualiza um objeto existente do tipo ProductsManagement com os dados fornecidos em um UpdateProductRequestDTO. Caso algum valor do DTO seja nulo ou inválido, mantém o valor existente.

ToCreateDTO(ProductsManagement model)
Converte um objeto do modelo ProductsManagement para o DTO CreateProductRequestDTO.

ToUpdateDTO(ProductsManagement model)
Converte um objeto do modelo ProductsManagement para o DTO UpdateProductRequestDTO.

*/

