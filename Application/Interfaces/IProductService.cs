using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ApiResponse<bool>> AddProduct(Product product);
    Task<ApiResponse<bool>> DeleteProduct(int id);
    Task<ApiResponse<bool>> UpdateProduct(Product product);
    Task<ApiResponse<Product>> GetProduct(int id);
    Task<ApiResponse<List<Product>>> GetProducts();
}
