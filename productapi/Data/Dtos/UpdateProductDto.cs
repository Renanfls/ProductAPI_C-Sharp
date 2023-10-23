using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data.Dtos;

public class UpdateProductDto
{
  [Required(ErrorMessage = "O nome do produto é obrigatório")]
  [StringLength(30, ErrorMessage = "A marca não pode exceder 30 caracteres")]
  public string Name { get; set; }
  [Required(ErrorMessage = "A marca do produto é obrigatória")]
  [StringLength(15, ErrorMessage = "A marca não pode exceder 15 caracteres")]
  public string Mark { get; set; }
  [Required(ErrorMessage = "A quantidade do produto é obrigatória")]
  [Range(0, 100, ErrorMessage = "A quantidade deve ter entre 0 até 100")]
  public int Quantity { get; set; } = 0;
}