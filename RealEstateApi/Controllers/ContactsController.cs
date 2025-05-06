using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.ContactDtos;
using RealEstateApi.Repositories.ContactRepositories;

namespace RealEstateApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContactsController : Controller
{
    private IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllContact()
    {
        var contacts = await _contactRepository.GetAllContactAsync();
        return Ok(contacts);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
         _contactRepository.CreateContactAsync(createContactDto);
        return Ok("Contact Created");
    }
    [HttpDelete("{contactId}")]
    public async Task<IActionResult> DeleteContact(int contactId)
    {
        _contactRepository.DeleteContactAsync(contactId);
        return Ok("Contact Deleted");
    }
    [HttpGet("{contactId}")]
    public async Task<IActionResult> GetByIdContact(int contactId)
    {
        var contact = await _contactRepository.GetByIdContactAsync(contactId);
        return Ok(contact);
    }
    [HttpGet("LastFourContact")]
    public async Task<IActionResult> GetLastFourContact()
    {
        var contacts = await _contactRepository.GetLastFourContactAsync();
        return Ok(contacts);
    }
}