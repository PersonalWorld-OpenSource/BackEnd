using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}