using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class PersonRepository : BaseRepository, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Person>> ListAsync()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task AddAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
    }

    public async Task<Person> FindByIdAsync(int id)
    {
        return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person> FindByEmailAsync(string email)
    {
        return await _context.Persons.SingleOrDefaultAsync(p => p.Email == email);
    }

    public bool ValidateEmail(string email)
    {
        return _context.Persons.Any(p => p.Email == email);
    }

    public Person FindById(int id)
    {
        return _context.Persons.Find(id);
    }

    public void Update(Person person)
    {
        _context.Persons.Update(person);
    }

    public void Remove(Person person)
    {
        _context.Persons.Remove(person);
    }
}