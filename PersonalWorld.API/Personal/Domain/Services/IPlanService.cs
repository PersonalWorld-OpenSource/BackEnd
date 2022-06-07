using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IPlanService
{
    Task<IEnumerable<Plan>> ListAsync();
    Task<PlanResponse> SaveAsync(Plan plan);
    Task<Plan> FindByIdAsync(int id);
    Task<PlanResponse> UpdateAsync(int id, Plan plan);
    Task<PlanResponse> DeleteAsync(int id);
}