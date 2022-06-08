using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface INotificationService 
{
    Task<IEnumerable<Notification>> ListAsync();
    Task<IEnumerable<Notification>> ListByPersonIdAsync(int personId);
    Task<NotificationResponse> FindByIdAsync(int id);
    Task<NotificationResponse> SaveAsync(Notification notification);
    Task<NotificationResponse> UpdateAsync(int id, Notification notification);
    Task<NotificationResponse> DeleteAsync(int id);
}