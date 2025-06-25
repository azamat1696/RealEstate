namespace RealEstateApi.Dto.ProductDtos;

public class GetProductDetailsByIdDto
{
    public int ProductDetailId { get; set; }
    public int ProductSize { get; set; }
    public int BedroomCount { get; set; }
    public int BathCount { get; set; }
    public int RoomCount { get; set; }
    public int GarageSize { get; set; }
    public int BuildYear { get; set; }
    public decimal Price { get; set; }
    public string? Location { get; set; }
    public string? VideoUrl { get; set; }
    public int ProductId { get; set; }
}