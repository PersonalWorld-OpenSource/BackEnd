using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IPlanRepository
{
    Task<IEnumerable<Plan>> ListAsync(); 
    Task AddAsync(Plan plan);
    Task<Plan> FindByIdAsync(int id);
    void Update(Plan plan);
    void Remove(Plan plan);
}