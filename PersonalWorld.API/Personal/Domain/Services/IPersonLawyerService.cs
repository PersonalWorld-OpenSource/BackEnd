using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IPersonLawyerService
{
    Task<IEnumerable<PersonLawyer>> ListAsync();

    Task<PersonLawyerResponse> SaveAsync(PersonLawyer personLawyer);

    Task<PersonLawyerResponse> FindByIdAsync(int id);

    Task<PersonLawyerResponse> UpdateAsync(int id, PersonLawyer personLawyer);

    Task<PersonLawyerResponse> DeleteAsync(int id);
}