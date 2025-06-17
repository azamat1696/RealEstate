using Dapper;
using RealEstateApi.Dto.MessageDtos;
using RealEstateApi.Models.DapperContext;

namespace RealEstateApi.Repositories.MessageRepositories;

public class MessageRepository : IMessageRepository
{
    private readonly Context _context;
    public MessageRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<ResultInBoxMessageDto>> GetInBoxLastThreeMessageListByReceiverIdAsync(int receiverId)
    {
       string query = "SELECT * FROM messages WHERE Receiver = @receiverId ORDER BY MessageId DESC LIMIT 3";
       var parameters = new DynamicParameters();
       parameters.Add("@receiverId", receiverId);
       using (var connection = _context.CreateConnection())
       {
           var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
           return values.ToList();
       }
    }
}