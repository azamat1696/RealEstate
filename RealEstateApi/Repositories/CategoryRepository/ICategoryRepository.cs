using RealEstateApi.Dto;

namespace RealEstateApi.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    void CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    void DeleteCategoryAsync(int categoryId);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(int categoryId);
}