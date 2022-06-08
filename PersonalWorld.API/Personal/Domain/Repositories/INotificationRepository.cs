using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> ListAsync();
    
    Task AddAsync(Notification consult);
    
    Task<Notification> FindByIdAsync(int id);

    Task<IEnumerable<Notification>> FindByPersonIdAsync(int personId);
    
    void Update(Notification consult);
    
    void Remove(Notification consult);
}