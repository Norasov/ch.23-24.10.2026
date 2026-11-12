using API.Extensions;
using Application.DTOs.Products;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service, ILogger<ProductsController> logger) : ControllerBase
{
    private readonly IProductService _service = service;
    private readonly ILogger<ProductsController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var products = await _service.GetProducts();
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, products.Type);
        return this.ToActionResult(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var product = await _service.GetProduct(id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, product.Type);
        return this.ToActionResult(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateProductDTO productDTO)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var add = await _service.AddProduct(productDTO);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, add.Type);
        return this.ToActionResult(add);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(UpdateProductDTO productDTO, int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var update = await _service.UpdateProduct(productDTO, id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, update.Type);
        return this.ToActionResult(update);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Request received: {Method} {Path}{Query}", Request.Method, Request.Path, Request.QueryString);
        var delete = await _service.DeleteProduct(id);
        _logger.LogInformation("Response sent: {Method} {Path}{Query} -> {Status}", Request.Method, Request.Path, Request.QueryString, delete.Type);
        return this.ToActionResult(delete);
    }
}
