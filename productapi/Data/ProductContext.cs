using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Data;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> opts) : base(opts)
  {
    
  }

  public DbSet<Product> Products { get; set; }
}
