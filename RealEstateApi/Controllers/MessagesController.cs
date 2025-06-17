using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.MessageRepositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : Controller
{
    private readonly IMessageRepository _messageRepository;
    public MessagesController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetInBoxLastThreeMessageListByReceiverId(int receiverId)
    {
        var values = await _messageRepository.GetInBoxLastThreeMessageListByReceiverIdAsync(receiverId);
        return Ok(values);
    }
}