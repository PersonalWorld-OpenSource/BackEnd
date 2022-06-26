using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Security.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IPersonService
{
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<Person>> ListAsync();
    Task RegisterAsync(RegisterPersonRequest request);
    //Task<PersonResponse> SaveAsync(Person person);
    Task<Person> FindByIdAsync(int id);
    Task UpdateAsync(int personId, UpdatePersonRequest person);
    Task DeleteAsync(int personId);
    //Task<PersonResponse> UpdateAsync(int id, Person person);
    //Task<PersonResponse> DeleteAsync(int id);
}