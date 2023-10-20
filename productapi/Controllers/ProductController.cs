using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

  private ProductContext _context;

  public ProductController(ProductContext context)
  {
    _context = context;
  }

  // Create
  [HttpPost]
  public IActionResult AddProduct([FromBody] Product product)
  {
    _context.Products.Add(product);
    _context.SaveChanges();
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
    return _context.Products.Skip(skip).Take(take);
  }

  [HttpGet("{id}")]
  public IActionResult ListProductById(int id)
  {
    var product = _context.Products.FirstOrDefault(product => product.Id == id);
    if (product == null) return NotFound();
    return Ok(product);
  }
}