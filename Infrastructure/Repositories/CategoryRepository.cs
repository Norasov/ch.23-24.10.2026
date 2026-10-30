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
    public async Task AddCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "insert into categories(name) values(@name)";
        await connection.ExecuteAsync(sql,category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "delete from categories where id = @id";
        await connection.ExecuteAsync(sql,new{id});
    }

    public async Task<int> GetAmountOfCategoriesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select count(*) from categories";
        var amount = await connection.ExecuteScalarAsync<int>(query);
        return amount;
    }


    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select id, name from categories";
        var category = await connection.QueryAsync<Category>(sql);
        return category.ToList();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "select * from categories where id = @id";
        return await connection.QueryFirstOrDefaultAsync<Category>(sql,new{id});
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        connection.Open();
        var sql = "update categories set name = @name where id = @id";
        await connection.ExecuteAsync(sql,category);
    }
}
