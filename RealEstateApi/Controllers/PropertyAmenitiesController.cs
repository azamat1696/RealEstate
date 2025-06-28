using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Repositories.PropertyAmenityRepositories;

namespace RealEstateApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyAmenitiesController : Controller
{
     private readonly IPropertyAmenityRepository _propertyAmenityRepository;
     public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
     {
         _propertyAmenityRepository = propertyAmenityRepository;
     }

     [HttpGet]
     public async Task<IActionResult> GetAllPropertyAmenityByStatusTrueAsync(int propertyId)
     {
         var propertyAmenities = await _propertyAmenityRepository.GetAllPropertyAmenityByStatusTrueAsync(propertyId);
         return Ok(propertyAmenities);
     }
}