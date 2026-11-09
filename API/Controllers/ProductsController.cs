using System.Runtime.InteropServices;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;

    [HttpGet]
    public async Task<ApiResponse<List<Product>>> GetProducts()
    {
        return  await _service.GetProducts();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Product>> GetProduct(int id)
    {
        return await _service.GetProduct(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Product product)
    {
        return await _service.AddProduct(product);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> Update(Product product)
    {
        return await _service.UpdateProduct(product);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await _service.DeleteProduct(id);
    }
}
