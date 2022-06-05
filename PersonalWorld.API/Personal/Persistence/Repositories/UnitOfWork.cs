using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}