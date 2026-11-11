using Application.DTOs.Categories;
using Application.HttpStatusCodes;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ServiceStatusCodes<bool>> AddCategory(CreateCategoryDTO createCategoryDTO);
    Task<ServiceStatusCodes<bool>> DeleteCategory(int id);
    Task<ServiceStatusCodes<bool>> UpdateCategory(UpdateCategoryDTO updateCategoryDTO, int id);
    Task<ServiceStatusCodes<CategoryDTO>> GetCategory(int id);
    Task<ServiceStatusCodes<List<CategoryDTO>>> GetCategories();
    Task<ServiceStatusCodes<int>> GetAmountOfCategories();
}
