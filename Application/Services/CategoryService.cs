using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    private readonly ICategoryRepository _repository = repository;
    public async Task<ApiResponse<bool>> AddCategory(Category category)
    {
        var addCategory = await _repository.AddCategoryAsync(category);
        return addCategory == true
        ? new ApiResponse<bool>(HttpStatusCode.Created,"Added!", addCategory)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest, "Not added!", false);
    }

    public async Task<ApiResponse<bool>> DeleteCategory(int id)
    {
        var delete = await _repository.DeleteCategoryAsync(id);
        return delete == true
        ? new ApiResponse<bool>(HttpStatusCode.NoContent, "Deleted!", true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not deleted!", false);
    }

    public async Task<ApiResponse<List<Category>>> GetCategories()
    {
        var categories = await _repository.GetCategoriesAsync();
        return new ApiResponse<List<Category>>(HttpStatusCode.OK, "list of categories", categories);
    }

    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        var get = await _repository.GetCategoryAsync(id);
        return get != null
        ? new ApiResponse<Category>(HttpStatusCode.OK, "Category with id", get)
        : new ApiResponse<Category>(HttpStatusCode.NotFound, "Not found!");
    }

    public async Task<ApiResponse<bool>> UpdateCategory(Category category)
    {
        var update = await _repository.UpdateCategoryAsync(category);
        return update == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound, "Not found!", false);
    }

}
