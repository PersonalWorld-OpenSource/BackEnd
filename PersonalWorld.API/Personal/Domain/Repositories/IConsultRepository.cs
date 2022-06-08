using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IConsultRepository
{
    Task<IEnumerable<Consult>> ListAsync();
    
    Task AddAsync(Consult consult);
    
    Task<Consult> FindByIdAsync(int id);

    Task<IEnumerable<Consult>> FindByLawyerIdAsync(int lawyerId);
    
    Task<IEnumerable<Consult>> FindByClientIdAsync(int clientId);
    
    void Update(Consult consult);
    
    void Remove(Consult consult);
}