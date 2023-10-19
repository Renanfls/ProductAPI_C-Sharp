using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data;

public class ProductContext : DbContext
{
  public ProductContext(DbContextOptions<ProductContext> opts) : base(opts)
  {
    
  }
}
