namespace RealEstateApi.Dto.ProductDtos;

public class ResultProductDto
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int ProductCategory { get; set; }
}