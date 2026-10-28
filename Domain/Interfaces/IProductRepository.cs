using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    void AddProduct(Product product);
    void DeleteProduct(int id);
    void UpdateProduct(Product product);
    Product GetProduct(int id);
    List<Product> GetProducts();
    List<Product> GetProductsByCategory(string name);
    int GetAmountOfProducts();
    int GetAmountOfProductsByCategory(int categoryId);
    decimal GetMinPriceOfProductByCategory(int categoryId);
    decimal GetMaxPriceOfProductByCategory(int categoryId);
    decimal GetAveragePriceOfProductByCategory(int categoryId);
    decimal GetTotalPriceOfProducts();
}
