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
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);

        var categories = await _service.GetCategories();
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, categories.Type);
        return this.ToActionResult(categories);
    }

    [HttpGet("amount-of-category")]
    public async Task<IActionResult> GetAmount()
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);

        var amount = await _service.GetAmountOfCategories();
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, amount.Type);
        return this.ToActionResult(amount);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);

        var category = await _service.GetCategory(id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, category.Type);
        return this.ToActionResult(category);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateCategoryDTO categoryDTO)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);

        var add = await _service.AddCategory(categoryDTO);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, add.Type);
        return this.ToActionResult(add);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO, int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);

        var update = await _service.UpdateCategory(categoryDTO, id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, update.Type);
        return this.ToActionResult(update);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var delete = await _service.DeleteCategory(id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, delete.Type);
        return this.ToActionResult(delete);
    }
}