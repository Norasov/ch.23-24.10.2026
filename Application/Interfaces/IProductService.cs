using Application.DTOs.Products;
using Application.HttpStatusCodes;

namespace Application.Interfaces;

public interface IProductService
{
    Task<ServiceStatusCodes<bool>> AddProduct(CreateProductDTO productDTO);
    Task<ServiceStatusCodes<bool>> DeleteProduct(int id);
    Task<ServiceStatusCodes<bool>> UpdateProduct(UpdateProductDTO productDTO, int id);
    Task<ServiceStatusCodes<ProductDTO>> GetProduct(int id);
    Task<ServiceStatusCodes<List<ProductDTO>>> GetProducts();
}
