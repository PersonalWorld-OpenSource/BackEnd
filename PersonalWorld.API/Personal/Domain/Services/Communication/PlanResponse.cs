using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class PlanResponse : BaseResponse<Plan>
{
    public PlanResponse(Plan resource) : base(resource)
    {
    }

    public PlanResponse(string message) : base(message)
    {
    }
}