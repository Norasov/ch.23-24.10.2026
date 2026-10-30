using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DapperContext _context;
    public ProductRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task AddProductAsync(Product product)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "insert into products(name,price,categoryid) values(@name,@price,@categoryid)";
        await connection.ExecuteAsync(sql, product);
    }

    public async Task DeleteProductAsync(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "delete from products where id = @id";
        await connection.QueryFirstOrDefaultAsync<Product>(sql, new { id });
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name, price from products";
        var products = await connection.QueryAsync<Product>(sql);
        return products.ToList();
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name, price, categoryid from products where id = @id";
        return await connection.QueryFirstOrDefaultAsync<Product>(sql, new { id });
    }

    public async Task UpdateProductAsync(Product product)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "update products set name = @name, price = @price, categoryid= @categoryid where id = @id";
        await connection.ExecuteAsync(sql, product);
    }

    public async Task<List<Product>> GetProductsByCategoryAsync(string name)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = @"select p.id, p.name, p.price 
        from products p 
        join categories c on c.id= p.categoryid
        where c.name = @category";
        var products = await connection.QueryAsync<Product>(sql, new { name });
        return products.ToList();
    }

    public async Task<int> GetAmountOfProductsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from products";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetAmountOfProductsByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select count(*) from products
        where categoryid = @categoryid";
        return await connection.ExecuteScalarAsync<int>(query, new { categoryId });
    }

    public async Task<decimal> GetMinPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select min(price) from products
        where categoryid = @categoryid";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });
    }

    public async Task<decimal> GetMaxPriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select max(price) from products
        where categoryid = @categoryid";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });

    }

    public async Task<decimal> GetAveragePriceOfProductByCategoryAsync(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select round(avg(price),2) from products
        where categoryid = @categoryid";
        return await connection.ExecuteScalarAsync<decimal>(query, new { categoryId });

    }

    public async Task<decimal> GetTotalPriceOfProductsAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select sum(price) from products";
        return await connection.ExecuteScalarAsync<decimal>(query);
    }
}
