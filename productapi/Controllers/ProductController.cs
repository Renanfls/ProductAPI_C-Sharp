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
  public IActionResult AddProduct([FromBody] Product product)
  {
    product.Id = id++;
    products.Add(product);
    return CreatedAtAction(
      nameof(ListProductById),
      new { id = product.Id },
      product
    );
  }

  // Read
  [HttpGet]
  public IEnumerable<Product> ListProducts([FromQuery] int skip = 0,[FromQuery] int take = 50)
  {
    return products.Skip(skip).Take(take);
  }

  [HttpGet("{id}")]
  public IActionResult ListProductById(int id)
  {
    var product = products.FirstOrDefault(product => product.Id == id);
    if (product == null) return NotFound();
    return Ok(product);
  }
}