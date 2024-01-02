using System.ComponentModel.DataAnnotations;

namespace ProductApi.Data.Dtos;

public class UpdateProductDto
{
  [Required(ErrorMessage = "O nome do produto é obrigatório")]
  [MaxLength(30, ErrorMessage = "A marca não pode exceder 30 caracteres")]
  public string Name { get; set; }
  // [Required(ErrorMessage = "A descrição do produto é obrigatória")]
  [MaxLength(100, ErrorMessage = "A descrição não pode exceder 100 caracteres")]
  public string Subject { get; set; }

  [Required(ErrorMessage = "O preço do produto é obrigatória")]
  public float Price { get; set; }

  [Required(ErrorMessage = "A imagem do produto é obrigatória")]
  public string Image { get; set; }
}