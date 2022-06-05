using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> ListAsync();
    Task AddAsync(Person person);
    Task<Person> FindByIdAsync(int id);
    void Update(Person person);
    void Remove(Person person);
}