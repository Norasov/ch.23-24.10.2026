using Application.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<bool>> AddCategory(Category category);
    Task<ApiResponse<bool>> DeleteCategory(int id);
    Task<ApiResponse<bool>> UpdateCategory(Category category);
    Task<ApiResponse<Category>> GetCategory(int id);
    Task<ApiResponse<List<Category>>> GetCategories();
}
