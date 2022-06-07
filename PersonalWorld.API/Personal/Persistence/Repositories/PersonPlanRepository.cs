using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class PersonPlanRepository : BaseRepository, IPersonPlanRepository
{
    public PersonPlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PersonPlan>> ListAsync()
    {
        return await _context.PersonPlans
            .Include(p => p.Plan)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public async Task AddAsync(PersonPlan personPlan)
    {
        await _context.PersonPlans.AddAsync(personPlan);
    }

    public async Task<PersonPlan> FindByIdAsync(int id)
    {
        return await _context.PersonPlans.FindAsync(id);
    }

    public void Update(PersonPlan personPlan)
    {
        _context.Update(personPlan);
    }

    public void Remove(PersonPlan personPlan)
    {
        _context.Remove(personPlan);
    }

    public async Task<IEnumerable<PersonPlan>> FindByPersonIdAsync(int idPerson)
    {
        return await _context.PersonPlans
            .Where(p => p.PersonId == idPerson)
            .Include(p => p.Person)
            .Include(p => p.Plan)
            .ToListAsync();
    }

    public async Task<PersonPlan> FindLastByPersonIdAsync(int idPerson)
    {
        return await _context.PersonPlans
            .Where(p => p.PersonId == idPerson)
            .Include(p => p.Person)
            .Include(p => p.Plan)
            .OrderByDescending(p => p.Date)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PersonPlan>> FindByPlanAsync(int idPlan)
    {
        return await _context.PersonPlans
            .Where(p => p.PlanId == idPlan)
            .Include(p => p.Person)
            .Include(p => p.Plan)
            .ToListAsync();
    }
}