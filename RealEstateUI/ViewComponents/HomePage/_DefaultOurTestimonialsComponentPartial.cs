using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.TestimonialDtos;

namespace RealEstateUI.ViewComponents.HomePage;

public class _DefaultOurTestimonialsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _DefaultOurTestimonialsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/Testimonial");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var testimonials = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(testimonials);
        }
        return View();
    }
}