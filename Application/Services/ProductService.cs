using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    private readonly IProductRepository _repository = repository;
    public async Task<ApiResponse<bool>> AddProduct(Product product)
    {
        var addProduct = await _repository.AddProductAsync(product);
        return addProduct == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", addProduct)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added!", addProduct);
    }

    public async Task<ApiResponse<bool>> DeleteProduct(int id)
    {
        var deleteProduct = await _repository.DeleteProductAsync(id);
        return deleteProduct == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", deleteProduct)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", deleteProduct);
    }

    public async Task<ApiResponse<Product>> GetProduct(int id)
    {
        var getProduct = await _repository.GetProductAsync(id);
        return getProduct != null
        ? new ApiResponse<Product>(HttpStatusCode.OK, "Product with id", getProduct)
        : new ApiResponse<Product>(HttpStatusCode.NotFound, "Product not found.");
    }

    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        var products = await _repository.GetProductsAsync();
        return new ApiResponse<List<Product>>(HttpStatusCode.OK, "list of products", products);
    }

    public async Task<ApiResponse<bool>> UpdateProduct(Product product)
    {
        var updateProduct = await _repository.UpdateProductAsync(product);
        return updateProduct == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not updated!", false); 
    }

}
