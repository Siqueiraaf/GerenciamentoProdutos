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


