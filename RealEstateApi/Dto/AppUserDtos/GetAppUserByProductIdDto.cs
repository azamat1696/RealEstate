namespace RealEstateApi.Dto.AppUserDtos;

public class GetAppUserByProductIdDto
{
    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public string image_url { get; set; }
    public string phone { get; set; }
}