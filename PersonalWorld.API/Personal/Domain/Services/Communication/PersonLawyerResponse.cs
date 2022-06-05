using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class PersonLawyerResponse : BaseResponse<PersonLawyer>
{
    public PersonLawyerResponse(PersonLawyer resource) : base(resource)
    {
    }

    public PersonLawyerResponse(string message) : base(message)
    {
    }
}