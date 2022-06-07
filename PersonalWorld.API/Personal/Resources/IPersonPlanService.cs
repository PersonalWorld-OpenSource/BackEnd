using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Resources;

public interface IPersonPlanService
{
    
    Task<IEnumerable<PersonPlan>> ListAsync();
    Task<PersonPlanResponse> SaveAsync(PersonPlan personPlan);
    Task<PersonPlan> FindByIdAsync(int id);
    Task<PersonPlanResponse> Remove(int  id);
    
    Task<IEnumerable<PersonPlan>> FindByPersonIdAsync(int idPerson);
    Task<PersonPlan> FindLastByPersonIdAsync(int idPerson);
    Task<IEnumerable<PersonPlan>> FindByPlanAsync(int idPlan);
}