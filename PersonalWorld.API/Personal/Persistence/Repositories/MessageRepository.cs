using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class MessageRepository : BaseRepository, IMessageRepository
{
    public MessageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Message>> ListAsync()
    {
        return await _context.Messages
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public async Task AddAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
    }

    public async Task<Message> FindByIdAsync(int id)
    {
        return await _context.Messages
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Message>> FindByPersonIdAsync(int personId)
    {
        return await _context.Messages
            .Where(p => p.PersonId == personId)
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public void Remove(Message message)
    {
        _context.Remove(message);
    }
}