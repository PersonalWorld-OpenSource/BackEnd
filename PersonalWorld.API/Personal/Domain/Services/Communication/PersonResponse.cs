using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Shared.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services.Communication;

public class PersonResponse  : BaseResponse<Person>
{
    public PersonResponse(Person resource) : base(resource)
    {
    }

    public PersonResponse(string message) : base(message)
    {
    }
}