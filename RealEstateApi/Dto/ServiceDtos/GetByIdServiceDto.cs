namespace RealEstateApi.Dto.ServiceDtos;

public class GetByIdServiceDto
{
  public int  ServiceId { get; set; }
  public string  ServiceName { get; set; }
  public bool  ServiceStatus { get; set; }
}