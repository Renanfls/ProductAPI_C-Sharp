using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models;

public class Product
{
  [Key]
  [Required]
  public int Id { get; set; }
  [Required(ErrorMessage = "O nome do produto é obrigatório")]
  [MaxLength(30, ErrorMessage = "A marca não pode exceder 30 caracteres")]
  public string Name { get; set; }
  [Required(ErrorMessage = "A marca do produto é obrigatória")]
  [MaxLength(15, ErrorMessage = "A marca não pode exceder 15 caracteres")]
  public string Mark { get; set; }
  [Required(ErrorMessage = "A quantidade do produto é obrigatória")]
  [Range(0, 100, ErrorMessage = "A quantidade deve ter entre 0 até 100")]
  public int Quantity { get; set; } = 0;
}