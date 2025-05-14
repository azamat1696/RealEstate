using Microsoft.AspNetCore.SignalR;

namespace RealEstateApi.Hubs;

public class SignalRHub : Hub
{
    private readonly IHttpClientFactory _httpClientFactory;
    public SignalRHub(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task SendCategoryCount()
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("http://localhost:5059/api/Statistics/CategoryCount");
        var value1 = await responseMessage1.Content.ReadAsStringAsync();
        await Clients.All.SendAsync("ReceiveCategoryCount", value1);
    }
}