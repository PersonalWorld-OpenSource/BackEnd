using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IPersonService
{
    Task<IEnumerable<Person>> ListAsync();
    Task<PersonResponse> SaveAsync(Person person);
    Task<Person> FindByIdAsync(int id);
    Task<PersonResponse> UpdateAsync(int id, Person person);
    Task<PersonResponse> DeleteAsync(int id);
}