using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class ConsultResponse: BaseResponse<Consult>
{
    public ConsultResponse(Consult resource) : base(resource)
    {
    }
    
    public ConsultResponse(string message) : base(message)
    {
    }
}