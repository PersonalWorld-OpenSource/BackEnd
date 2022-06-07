using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class PlanRepository: BaseRepository, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Plan>> ListAsync()
    {
        return await _context.Plans.ToListAsync();

    }

    public async Task AddAsync(Plan plan)
    {
        await _context.Plans.AddAsync(plan);
    }

    public async Task<Plan> FindByIdAsync(int id)
    {
        return await _context.Plans.FindAsync(id);
    }

    public void Update(Plan plan)
    {
        _context.Plans.Update(plan);
    }

    public void Remove(Plan plan)
    {
        _context.Plans.Remove(plan);
    }
}