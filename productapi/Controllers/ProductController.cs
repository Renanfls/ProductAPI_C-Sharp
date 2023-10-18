using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
  private static List<Product> products = new();
  private static int id = 0;

  // Create
  [HttpPost]
  public void AddProduct([FromBody] Product product)
  {
    product.Id = id++;
    products.Add(product);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Mark);
    Console.WriteLine(product.Quantity);
  }

  // Read
  [HttpGet]
  public IEnumerable<Product> ListProducts([FromQuery] int skip,[FromQuery] int take)
  {
    return products.Skip(skip).Take(take);
  }

  [HttpGet("{id}")]
  public Product? ListProductById(int id)
  {
    return products.FirstOrDefault(product => product.Id == id);
  }
}