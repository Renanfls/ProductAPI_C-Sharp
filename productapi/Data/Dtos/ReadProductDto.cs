namespace ProductApi.Data.Dtos;

public class ReadProductDto
{
  public string Name { get; set; }
  public string Subject { get; set; }
  public float Price { get; set; }
  public string Image { get; set; }
  public DateTime AppointmentTime { get; set; } = DateTime.Now;
}