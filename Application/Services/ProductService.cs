using Application.DTOs.Products;
using Application.HttpStatusCodes;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    private readonly IProductRepository _repository = repository;
    public async Task<ServiceStatusCodes<bool>> AddProduct(CreateProductDTO productDTO)
    {
        Product product = new()
        {
            Name = productDTO.Name,
            Price = productDTO.Price,
            CategoryId = productDTO.CategoryId
        };
        var add = await _repository.AddProductAsync(product);
        if (!add)
            return ServiceStatusCodes<bool>.BadRequest("Не удалось добавить продукт.");

        return ServiceStatusCodes<bool>.Created(add);
    }

    public async Task<ServiceStatusCodes<bool>> DeleteProduct(int id)
    {
        var delete = await _repository.DeleteProductAsync(id);
        if (!delete)
            return ServiceStatusCodes<bool>.NotFound("Нет продукта с таким идентификатором.");

        return ServiceStatusCodes<bool>.NoContent();
    }

    public async Task<ServiceStatusCodes<ProductDTO>> GetProduct(int id)
    {
        var get = await _repository.GetProductAsync(id);

        if (get is null)
            return ServiceStatusCodes<ProductDTO>.NotFound("Нет продукта с таким идентификатором.");
        
        ProductDTO productDTO = new()
        {
            Name = get.Name,
            Price = get.Price,
            CategoryId = get.CategoryId
        };

        return ServiceStatusCodes<ProductDTO>.Ok(productDTO);
    }

    public async Task<ServiceStatusCodes<List<ProductDTO>>> GetProducts()
    {
        var products = await _repository.GetProductsAsync();
        List<ProductDTO> productDTOs = [];
        foreach (var product in products)
        {
            ProductDTO productDTO = new()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
            productDTOs.Add(productDTO);
        }
        return ServiceStatusCodes<List<ProductDTO>>.Ok(productDTOs);
    }

    public async Task<ServiceStatusCodes<bool>> UpdateProduct(UpdateProductDTO productDTO, int id)
    {
        var update = await _repository.GetProductAsync(id);
        if (update is null)
            return ServiceStatusCodes<bool>.NotFound("Нет продукта с таким идентификатором.");
        
        update.Name = productDTO.Name;
        update.Price = productDTO.Price;
        update.CategoryId = productDTO.CategoryId;

        var updated =await _repository.UpdateProductAsync(update);

        if(!updated)
            return ServiceStatusCodes<bool>.BadRequest("Не удалось обновить продукт.");

        return ServiceStatusCodes<bool>.Ok(true);
    }
}
