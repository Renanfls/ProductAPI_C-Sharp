using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> opts) : base(opts)
  {
    
  }

  public DbSet<Product> Products { get; set; }
}
