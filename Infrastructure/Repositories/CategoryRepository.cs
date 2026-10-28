using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;
    public CategoryRepository(DapperContext context)
    {
        _context=context;
    }
    public void AddCategory(Category category)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "insert into categories(name) values(@name)";
        connection.Execute(sql,category);
    }

    public void DeleteCategory(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "delete from categories where id = @id";
        connection.Execute(sql,new{id});
    }

    public int GetAmountOfCategories()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from categories";
        return connection.ExecuteScalar<int>(query);
    }


    public List<Category> GetCategories()
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name from categories";
        return connection.Query<Category>(sql).ToList();
    }

    public Category GetCategory(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select * from categories where id = @id";
        return connection.QueryFirst<Category>(sql,new{id});
    }

    public void UpdateCategory(Category category)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "update categories set name = @name where id = @id";
        connection.QueryFirst<Category>(sql,category);
    }
}
