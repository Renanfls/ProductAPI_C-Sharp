using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Data.Dtos;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

  private ProductContext _context;
  private IMapper _mapper;

  public ProductController(ProductContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  /// <summary>
  /// Adiciona um produto ao banco de dados
  /// </summary>
  /// <param name="productDto">Objeto com os campos necessários para criação de um produto</param>
  /// <returns>IActionResult</returns>
  /// <response code="201">Caso inserção seja feita com sucesso</response>
  // Create
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  public IActionResult AddProduct(
    [FromBody] CreateProductDto productDto)
  {
    Product product = _mapper.Map<Product>(productDto);
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
  public IEnumerable<ReadProductDto> ListProducts([FromQuery] int skip = 0,[FromQuery] int take = 50)
  {
    return _mapper.Map<List<ReadProductDto>>(_context.Products.Skip
    (skip).Take(take));
  }

  [HttpGet("{id}")]
  public IActionResult ListProductById(int id)
  {
    var product = _context.Products.FirstOrDefault(
        product => product.Id == id);
    if (product == null) return NotFound();
    var productDto = _mapper.Map<ReadProductDto>(product);
    return Ok(product);
  }

  // Update
  [HttpPut("{id}")]
  public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
  {
    var product = _context.Products.FirstOrDefault(product => product.Id == id);
    if (product == null) return NotFound();
    _mapper.Map(productDto, product);
    _context.SaveChanges();
    return NoContent();
  }

  [HttpPatch("{id}")]
  public IActionResult UpdateProductPatch(int id, 
    JsonPatchDocument<UpdateProductDto> patch)
  {
    var product = _context.Products.FirstOrDefault(
        product => product.Id == id);
    if (product == null) return NotFound();

    var productToUpdate = _mapper.Map<UpdateProductDto>(product);

    patch.ApplyTo(productToUpdate, ModelState);

    if (!TryValidateModel(productToUpdate))
    {
      return ValidationProblem(ModelState);
    }
    
    _mapper.Map(productToUpdate, product);
    _context.SaveChanges();
    return NoContent();
  }

  // Delete
  [HttpDelete("{id}")]
  public IActionResult DeleteProduct(int id)
  {
    var product = _context.Products.FirstOrDefault(
        product => product.Id == id);
    if (product == null) return NotFound();
    _context.Remove(product);
    _context.SaveChanges();
    return NoContent();
  }
}
