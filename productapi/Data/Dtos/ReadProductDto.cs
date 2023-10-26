namespace ProductApi.Data.Dtos;

public class ReadProductDto
{
  public string Name { get; set; }
  public string Mark { get; set; }
  public int Quantity { get; set; } = 0;
  public DateTime AppointmentTime { get; set; } = DateTime.Now;
}