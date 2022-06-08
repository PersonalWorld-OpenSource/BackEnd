using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Persistence.Contexts;

namespace PersonalWorld.API.Personal.Persistence.Repositories;

public class NotificationRepository: BaseRepository,INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Notification>> ListAsync()
    {
        return await _context.Notifications
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public async Task AddAsync(Notification consult)
    {
        await _context.Notifications.AddAsync(consult);
    }

    public async Task<Notification> FindByIdAsync(int id)
    {
        return await _context.Notifications
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Notification>> FindByPersonIdAsync(int personId)
    {
        return await _context.Notifications
            .Where(p => p.Id == personId)
            .Include(p => p.Consult)
            .Include(p => p.Person)
            .ToListAsync();
    }

    public void Update(Notification consult)
    {
        _context.Notifications.Update(consult);
    }

    public void Remove(Notification consult)
    {
        _context.Notifications.Remove(consult);
    }
}