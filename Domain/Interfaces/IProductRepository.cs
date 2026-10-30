using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task UpdateProductAsync(Product product);
    Task<Product?> GetProductAsync(int id);
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsByCategoryAsync(string name);
    Task<int> GetAmountOfProductsAsync();
    Task<int> GetAmountOfProductsByCategoryAsync(int categoryId);
    Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId);
    Task<decimal> GetTotalPriceOfProductsAsync();
}
