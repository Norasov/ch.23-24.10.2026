using Application.DTOs.Categories;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Extensions;


namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ICategoryService service, ILogger<CategoriesController> logger) : ControllerBase
{
    private readonly ICategoryService _service = service;
    private readonly ILogger<CategoriesController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _service.GetCategories();
        return this.ToActionResult(categories);
    }

    [HttpGet("amount-of-category")]
    public async Task<IActionResult> GetAmount()
    {
        var amount = await _service.GetAmountOfCategories();
        return this.ToActionResult(amount);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _service.GetCategory(id);
        return this.ToActionResult(category);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateCategoryDTO categoryDTO)
    {
        var add = await _service.AddCategory(categoryDTO);
        return this.ToActionResult(add);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO, int id)
    {
        var update = await _service.UpdateCategory(categoryDTO, id);
        return this.ToActionResult(update);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _service.DeleteCategory(id);
        return this.ToActionResult(delete);
    }
}