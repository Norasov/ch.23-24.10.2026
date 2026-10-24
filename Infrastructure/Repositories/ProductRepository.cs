using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class ProductRepository:IProductRepository
{
        public void AddProduct(Product product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "insert into products(name,price,categoryid) values(@name,@price,@categoryid)";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("name", product.Name);
        cmd.Parameters.AddWithValue("price", product.Price);
        cmd.Parameters.AddWithValue("categoryid", product.CategoryId);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Added!");
    }

    public void DeleteProduct(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "delete from products where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id", id);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Deleted!");
        else System.Console.WriteLine("Product not found");
    }

    public List<Product> GetProducts()
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "select id, name, price from products";
        var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();
        List<Product> products = [];
        while (reader.Read())
        {
            Product product = new();
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
            products.Add(product);
        }
        return products;
    }

    public Product GetProduct(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "select id, name, price, categoryid from products where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id",id);
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Product product = new();
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
            product.CategoryId = reader.GetInt32(3);
            return product;
        }
        throw new Exception("Product not found");
    }

    public void UpdateProduct(Product product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "update products set name = @name, price = @price, categoryid= @categoryid where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id", product.Id);
        cmd.Parameters.AddWithValue("name", product.Name);
        cmd.Parameters.AddWithValue("price", product.Price);
        cmd.Parameters.AddWithValue("categoryid", product.CategoryId);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Updated!");
        else System.Console.WriteLine("product not found");
    }

    public List<Product> GetProductsByCategory(string name)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = @"select p.id, p.name, p.price 
        from products p 
        join categories c on c.id= p.categoryid
        where c.name = @category";
        var cmd = new NpgsqlCommand(sql,connection);
        cmd.Parameters.AddWithValue("name", name);
        var reader = cmd.ExecuteReader();
        List<Product> products = [];
        while (reader.Read())
        {
            Product product = new();
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
            products.Add(product);   
        }
        return products;
    }
}
