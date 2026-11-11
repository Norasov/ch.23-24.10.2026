using API.Extensions;
using Application.DTOs.Products;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _service.GetProducts();
        return this.ToActionResult(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _service.GetProduct(id);
        return this.ToActionResult(product);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateProductDTO productDTO)
    {
        var add = await _service.AddProduct(productDTO);
        return this.ToActionResult(add);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(UpdateProductDTO productDTO, int id)
    {
        var update = await _service.UpdateProduct(productDTO, id);
        return this.ToActionResult(update);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delete = await _service.DeleteProduct(id);
        return this.ToActionResult(delete);
    }
}
