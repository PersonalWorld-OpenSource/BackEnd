using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class PersonPlanResponse : BaseResponse<PersonPlan>
{
    public PersonPlanResponse(PersonPlan resource) : base(resource)
    {
    }

    public PersonPlanResponse(string message) : base(message)
    {
    }
}