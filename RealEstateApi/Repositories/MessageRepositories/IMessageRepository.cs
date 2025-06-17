using RealEstateApi.Dto.MessageDtos;

namespace RealEstateApi.Repositories.MessageRepositories;

public interface IMessageRepository
{
    Task<List<ResultInBoxMessageDto>> GetInBoxLastThreeMessageListByReceiverIdAsync(int receiverId);
    
}