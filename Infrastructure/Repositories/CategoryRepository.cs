using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> AddCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        var sql = "insert into categories(name) values(@name)";
        var addCategory = await connection.ExecuteAsync(sql, category);
        return addCategory > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        var sql = "delete from categories where id = @id";
        var deleteCategory = await connection.ExecuteAsync(sql, new { id });
        return deleteCategory > 0;
    }

    public async Task<int> GetAmountOfCategoriesAsync()
    {
        using var connection = _context.Connection();
        var query = "select count(*) from categories";
        var amount = await connection.ExecuteScalarAsync<int>(query);
        return amount;
    }


    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var connection = _context.Connection();
        var sql = "select id, name from categories";
        var category = await connection.QueryAsync<Category>(sql);
        return category.ToList();
    }

    public async Task<Category?> GetCategoryAsync(int id)
    {
        using var connection = _context.Connection();
        var sql = "select * from categories where id = @id";
        return await connection.QueryFirstOrDefaultAsync<Category>(sql, new { id });
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        using var connection = _context.Connection();
        var sql = "update categories set name = @name where id = @id";
        var updateCategory = await connection.ExecuteAsync(sql, category);
        return updateCategory > 0;
    }
}
