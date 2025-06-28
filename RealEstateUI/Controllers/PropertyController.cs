using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ProductDetailDtos;
using RealEstateUI.Dto.ProductDtos;
using RealEstateUI.Dto.ProductImageDtos;

namespace RealEstateUI.Controllers;

public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PropertyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Products/ProductsWithCategory");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return View(products);
        }
        return View();
    }
    [HttpGet("Property/Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/Products/GetProductById?id={id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync(); 
            var product = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
            ViewBag.ProductId = product.productId;
            ViewBag.ProductName = product.title;
            ViewBag.Price = product.price;
            ViewBag.City = product.city;
            ViewBag.District = product.district;
            ViewBag.Address = product.address;
            ViewBag.Product_Description = product.description;
            ViewBag.Type = product.type;
            ViewBag.Date = product.AdvertisementDate.ToString("dd-MM-yyyy");
            DateTime date1 = DateTime.Now;
            DateTime date2 = product.AdvertisementDate;
            if (date1 < date2)
            { 
                // date1 daha eski, swap
                (date1, date2) = (date2, date1);
            }

            int months = ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month;
            if (date1.Day < date2.Day)
            {
                months--;
            }
            ViewBag.DayDifference = months.ToString(); // Calculate the difference in months
            ViewBag.CoverImage = product.coverImage;
        }

        var detailResponse = await client.GetAsync($"http://localhost:5059/api/ProductDetails/GetProductDetailsById?id={id}");
        if (detailResponse.IsSuccessStatusCode) {
                var detailJsonData = await detailResponse.Content.ReadAsStringAsync();
                var productDetail = JsonConvert.DeserializeObject<ProductDetailDto>(detailJsonData);
                ViewBag.ProductDetailId = productDetail?.ProductDetailId;
                ViewBag.ProductSize = productDetail?.ProductSize;
                ViewBag.BedroomCount = productDetail?.BedroomCount;
                ViewBag.BathCount = productDetail?.BathCount;
                ViewBag.RoomCount = productDetail?.RoomCount;
                ViewBag.GarageSize = productDetail?.GarageSize;
                ViewBag.BuildYear = productDetail?.BuildYear;
                ViewBag.VideoUrl = productDetail?.VideoUrl;
                ViewBag.Location = productDetail?.Location;
                
        }
        return View();
         
    } 
    
    public async Task<IActionResult> PropertyListWithSearch(
        string searchText,
        int categoryId,
        string cityName
        )
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5059/api/Products/GetProductListBySearchAsync?searchText={searchText}&categoryId={categoryId}&cityName={cityName}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
            return View(products);
        }
        return View();
    }
}