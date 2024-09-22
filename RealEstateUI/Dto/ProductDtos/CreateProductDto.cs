namespace RealEstateUI.Dto.ProductDtos;

public class CreateProductDto
{
    public int productId { get; set; }
    public string title { get; set; }
    public decimal price { get; set; }
    public string city { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public string description { get; set; }
    public string coverImage { get; set; }
    public string type { get; set; }
    public int productCategory { get; set; }

}