using Domain.Entities;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task<bool> AddCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<Category?> GetCategoryAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}
