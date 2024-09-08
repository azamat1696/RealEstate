using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Dto.ServiceDtos;
using RealEstateApi.Repositories.ServiceRepository;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : Controller
{
    private readonly IServiceRepository _serviceRepository;
    public ServicesController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var services = await _serviceRepository.GetAllServiceAsync();
        return Ok(services);
    }
    [HttpPost]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceDto createServiceDto)
    {
        _serviceRepository.CreateServiceAsync(createServiceDto);
        return Ok("Service Created");
    }
    [HttpDelete("{serviceId}")]
    public async Task<IActionResult> DeleteService(int serviceId)
    {
        _serviceRepository.DeleteServiceAsync(serviceId);
        return Ok("Service Deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDto updateServiceDto)
    {
        await _serviceRepository.UpdateServiceAsync(updateServiceDto);
        return Ok("Service Updated");
    }
    [HttpGet("{serviceId}")]
    public async Task<IActionResult> GetByIdService(int serviceId)
    {
        var service = await _serviceRepository.GetByIdServiceAsync(serviceId);
        return Ok(service);
    }
 }