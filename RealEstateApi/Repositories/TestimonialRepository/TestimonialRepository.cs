using Dapper;
using RealEstateApi.Dto.TestimonialDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.TestimonialRepository;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly Context _context;
    public TestimonialRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
    {
        string query = "SELECT * FROM testimonial";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }
    }

    public async void CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
    {
       string query = "INSERT INTO testimonial (NameSurname, Title, Comment, Status) VALUES (@NameSurname, @Title, @Comment, @Status)";
       var parameters = new DynamicParameters();
            parameters.Add("@NameSurname", createTestimonialDto.NameSurname);
            parameters.Add("@Title", createTestimonialDto.Title);
            parameters.Add("@Comment", createTestimonialDto.Comment);
            parameters.Add("@Status", createTestimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
    }

    public async void DeleteTestimonialAsync(int id)
    {
       string query = "DELETE FROM testimonial WHERE TestimonialId = @TestimonialId";
       var parameters = new DynamicParameters();
         parameters.Add("@TestimonialId", id);
         using (var connection = _context.CreateConnection())
         {
             await connection.ExecuteAsync(query, parameters);
         }
    }

    public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
    {
        string query = "UPDATE testimonial SET NameSurname = @NameSurname, Title = @Title, Comment = @Comment, Status = @Status WHERE TestimonialId = @TestimonialId";
        var parameters = new DynamicParameters();
        parameters.Add("@NameSurname", updateTestimonialDto.NameSurname);
        parameters.Add("@Title", updateTestimonialDto.Title);
        parameters.Add("@Comment", updateTestimonialDto.Comment);
        parameters.Add("@Status", updateTestimonialDto.Status);
        parameters.Add("@TestimonialId", updateTestimonialDto.TestimonialId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdTestimonialDto> GetByIdTestimonialAsync(int id)
    {
        string query = "SELECT * FROM testimonial WHERE TestimonialId = @TestimonialId";
        var parameters = new DynamicParameters();
        parameters.Add("@TestimonialId", id);
        using (var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdTestimonialDto>(query, parameters);
        }
    }
}