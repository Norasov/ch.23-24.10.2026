using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Category category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "insert into categories(name) values(@name)";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("name", category.Name);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Added!");
    }

    public void DeleteCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "delete from categories where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id", id);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Deleted!");
        else System.Console.WriteLine("Category not found");
    }

    public List<Category> GetCategories()
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "select id, name from categories";
        var cmd = new NpgsqlCommand(sql, connection);
        var reader = cmd.ExecuteReader();
        List<Category> categories = [];
        while (reader.Read())
        {
            Category category = new();
            category.Id = reader.GetInt32(0);
            category.Name = reader.GetString(1);
            categories.Add(category);
        }
        return categories;
    }

    public Category GetCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "select * from categories where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id",id);
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            Category category = new();
            category.Id = reader.GetInt32(0);
            category.Name = reader.GetString(1);
            return category;
        }
        throw new Exception("Category not found");
    }

    public void UpdateCategory(Category category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var sql = "update categories set name = @name where id = @id";
        var cmd = new NpgsqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("id", category.Id);
        cmd.Parameters.AddWithValue("name", category.Name);
        int result = cmd.ExecuteNonQuery();
        if (result > 0) System.Console.WriteLine("Updated!");
        else System.Console.WriteLine("category not found");
    }
}
