namespace RealEstateApi.Dto.ProductImageDtos;

public class GetProductImageByProductIdDto
{
    public int id { get; set; }
    public string ImageUrl { get; set; }
    public int ProductId { get; set; }
}