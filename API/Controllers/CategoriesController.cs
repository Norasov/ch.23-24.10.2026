using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService service) : ControllerBase
{
        private readonly ICategoryService _service = service;

    [HttpGet]
    public async Task<ApiResponse<List<Category>>> GetCategorys()
    {
        return  await _service.GetCategories();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Category>> GetCategory(int id)
    {
        return await _service.GetCategory(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Category category)
    {
        return await _service.AddCategory(category);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> Update(Category category)
    {
        return await _service.UpdateCategory(category);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await _service.DeleteCategory(id);
    }

}
