using RealEstateApi.Dto;
using RealEstateApi.Dto.TestimonialDtos;

namespace RealEstateApi.Repositories.TestimonialRepository;

public interface ITestimonialRepository
{
    Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    void CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
    void DeleteTestimonialAsync(int id);
    Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
    Task<GetByIdTestimonialDto> GetByIdTestimonialAsync(int id);
}