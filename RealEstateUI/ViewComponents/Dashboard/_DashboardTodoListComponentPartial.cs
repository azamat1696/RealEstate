using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateUI.Dto.ContactDtos;
using RealEstateUI.Dto.TodoListDtos;

namespace RealEstateUI.ViewComponents.Dashboard;

public class _DashboardTodoListComponentPartial : ViewComponent
{
    protected readonly IHttpClientFactory _httpClientFactory;
    public _DashboardTodoListComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5059/api/TodoList/GetLastFiveTodoList");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var todoList = JsonConvert.DeserializeObject<List<ResultTodoListDto>>(jsonData);
            return View(todoList);
        }
        return View();
    }
}