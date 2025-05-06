namespace RealEstateApi.Dto.TodoListDtos;

public class GetByIdTodoListDto
{
    public int id { get; set; }
    public string task { get; set; }
    public bool completed { get; set; }
}