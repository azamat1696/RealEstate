using Dapper;
using RealEstateApi.Dto.WhoWeAreDetailDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.WhoWeAreDetailRepository;

public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
{
    private readonly Context _context;
    public WhoWeAreDetailRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
    {
        string query = "SELECT * FROM who_we_are_detail";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
            return values.ToList();
        }
    }

    public async void CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
    {
        string query = "INSERT INTO who_we_are_detail (Title, SubTitle,Description1,Description2) VALUES (@Title, @SubTitle,@Description1,@Description2)";
        var parameters = new DynamicParameters();
        parameters.Add("Title",createWhoWeAreDetailDto.Title);
        parameters.Add("SubTitle",createWhoWeAreDetailDto.SubTitle);
        parameters.Add("Description1",createWhoWeAreDetailDto.Description1);
        parameters.Add("Description2",createWhoWeAreDetailDto.Description2);
        
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters); 
        }
    }

    public async void DeleteWhoWeAreDetailAsync(int id)
    {
        string query = "DELETE FROM who_we_are_detail WHERE WhoWeAreDetailId = @WhoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@WhoWeAreDetailId", id);
        using (var connection = _context.CreateConnection())
        {
           await connection.ExecuteAsync(query, parameters);
        }
    }
    
    public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
    {
        string query = "UPDATE who_we_are_detail SET Title = @Title, SubTitle = @SubTitle, Description1 = @Description1, Description2 = @Description2 WHERE WhoWeAreDetailId = @WhoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", updateWhoWeAreDetailDto.Title);
        parameters.Add("@SubTitle", updateWhoWeAreDetailDto.SubTitle);
        parameters.Add("@Description1", updateWhoWeAreDetailDto.Description1);
        parameters.Add("@Description2", updateWhoWeAreDetailDto.Description2);
        parameters.Add("@WhoWeAreDetailId", updateWhoWeAreDetailDto.WhoWeAreDetailId);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetailAsync(int id)
    {
        string query = "SELECT * FROM who_we_are_detail WHERE WhoWeAreDetailId = @WhoWeAreDetailId";
        var parameters = new DynamicParameters();
        parameters.Add("@WhoWeAreDetailId", id);
        using ( var connection = _context.CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
        }
    }
}