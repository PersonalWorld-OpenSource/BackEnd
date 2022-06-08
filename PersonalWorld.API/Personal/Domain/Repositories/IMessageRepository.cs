using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> ListAsync();

    Task AddAsync(Message message);

    Task<Message> FindByIdAsync(int id);

    Task<IEnumerable<Message>> FindByPersonIdAsync(int personId);

    void Remove(Message message);
}