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
    public void AddProduct(Product product)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "insert into products(name,price,categoryid) values(@name,@price,@categoryid)";
        connection.Execute(sql, product);
    }

    public void DeleteProduct(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "delete from products where id = @id";
        connection.QueryFirst<Product>(sql, new { id });
    }

    public List<Product> GetProducts()
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name, price from products";
        return connection.Query<Product>(sql).ToList();
    }

    public Product GetProduct(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name, price, categoryid from products where id = @id";
        return connection.QueryFirst<Product>(sql, new { id });
    }

    public void UpdateProduct(Product product)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "update products set name = @name, price = @price, categoryid= @categoryid where id = @id";
        connection.Execute(sql, product);
    }

    public List<Product> GetProductsByCategory(string name)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = @"select p.id, p.name, p.price 
        from products p 
        join categories c on c.id= p.categoryid
        where c.name = @category";
        return connection.Query<Product>(sql, new { name }).ToList();
    }

    public int GetAmountOfProducts()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from products";
        return connection.ExecuteScalar<int>(query);
    }

    public int GetAmountOfProductsByCategory(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select count(*) from products
        where categoryid = @categoryid";
        return connection.ExecuteScalar<int>(query, new { categoryId });
    }

    public decimal GetMinPriceOfProductByCategory(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select min(price) from products
        where categoryid = @categoryid";
        return connection.ExecuteScalar<decimal>(query, new { categoryId });
    }

    public decimal GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select max(price) from products
        where categoryid = @categoryid";
        return connection.ExecuteScalar<decimal>(query, new { categoryId });

    }

    public decimal GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select round(avg(price),2) from products
        where categoryid = @categoryid";
        return connection.ExecuteScalar<decimal>(query, new { categoryId });

    }

    public decimal GetTotalPriceOfProducts()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = @"select sum(price) from products";
        return connection.ExecuteScalar<decimal>(query);
    }

}
