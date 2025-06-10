namespace RealEstateUI.Models;

public class JwtResponseModel
{
    public string token { get; set; }
    public DateTime expireDate { get; set; }
}