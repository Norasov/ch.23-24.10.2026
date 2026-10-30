using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    Task UpdateCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}
