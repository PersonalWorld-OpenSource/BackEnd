using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class NotificationResponse: BaseResponse<Notification>
{
    public NotificationResponse(Notification resource) : base(resource)
    {
    }
    
    public NotificationResponse(string message) : base(message)
    {
    }
}