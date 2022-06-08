using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class MessageResponse : BaseResponse<Message>
{
    public MessageResponse(Message resource) : base(resource)
    {
    }

    public MessageResponse(string message) : base(message)
    {
    }
}