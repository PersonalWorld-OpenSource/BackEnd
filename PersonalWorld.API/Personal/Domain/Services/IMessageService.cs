using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IMessageService
{
    Task<IEnumerable<Message>> ListAsync();

    Task<MessageResponse> FindByIdAsync(int id);
    
    Task<IEnumerable<Message>> ListByPersonIdAsync(int personId);
    
    Task<MessageResponse> SaveAsync(Message message);

    Task<MessageResponse> DeleteAsync(int id);
}