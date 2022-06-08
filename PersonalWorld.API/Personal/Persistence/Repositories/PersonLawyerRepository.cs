using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class PersonLawyerRepository : BaseRepository, IPersonLawyerRepository
{
    public PersonLawyerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PersonLawyer>> ListAsync()
    {
        return await _context.Lawyers.ToListAsync();
    }

    public async Task AddAsync(PersonLawyer personLawyer)
    {
        await _context.Lawyers.AddAsync(personLawyer);
    }

    public async Task<PersonLawyer> FindByIdAsync(int id)
    {
        return await _context.Lawyers.FindAsync(id);
    }

    public void Update(PersonLawyer personLawyer)
    {
        _context.Update(personLawyer);
    }

    public void Remove(PersonLawyer personLawyer)
    {
        _context.Remove(personLawyer);
    }
}