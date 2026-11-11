using Application.DTOs.Categories;
using Application.HttpStatusCodes;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    private readonly ICategoryRepository _repository = repository;
    
    public async Task<ServiceStatusCodes<bool>> AddCategory(CreateCategoryDTO categoryDTO)
    {
        Category category = new()
        {
            Name = categoryDTO.Name
        };
        var add = await _repository.AddCategoryAsync(category);
        if(!add)
            return ServiceStatusCodes<bool>.BadRequest("Не удалось добавить категорию.");
        return ServiceStatusCodes<bool>.Created(add);
    }

    public async Task<ServiceStatusCodes<bool>> DeleteCategory(int id)
    {
        var delete = await _repository.DeleteCategoryAsync(id);
        if(!delete)
            return ServiceStatusCodes<bool>.NotFound("Нет категории с таким идентификатором.");

        return ServiceStatusCodes<bool>.NoContent();
    }

    public async Task<ServiceStatusCodes<int>> GetAmountOfCategories()
    {
        var amount = await _repository.GetAmountOfCategoriesAsync();
        return ServiceStatusCodes<int>.Ok(amount);
    }


    public async Task<ServiceStatusCodes<List<CategoryDTO>>> GetCategories()
    {
        var categories = await _repository.GetCategoriesAsync();
        
        List<CategoryDTO> categoryDTOs = [];
        foreach (var category in categories)
        {
            CategoryDTO categoryDTO = new();
            categoryDTO.Name = category.Name;
            categoryDTOs.Add(categoryDTO);
        }

        return ServiceStatusCodes<List<CategoryDTO>>.Ok(categoryDTOs);
    }

    public async Task<ServiceStatusCodes<CategoryDTO>> GetCategory(int id)
    {
        var get = await _repository.GetCategoryAsync(id);
        if(get is null)
            return ServiceStatusCodes<CategoryDTO>.NotFound("Нет категории с таким идентификатором");

        CategoryDTO categoryDTO = new();
        categoryDTO.Name = get.Name;

        return ServiceStatusCodes<CategoryDTO>.Ok(categoryDTO);
    }

    public async Task<ServiceStatusCodes<bool>> UpdateCategory(UpdateCategoryDTO categoryDTO, int id)
    {        
        var update = await _repository.GetCategoryAsync(id);
        
        if(update is null)
            return ServiceStatusCodes<bool>.NotFound("Нет категории с таким идентификатором.");
        

        update.Name = categoryDTO.Name;
        await _repository.UpdateCategoryAsync(update);

        return ServiceStatusCodes<bool>.Ok(true);
    }
}
