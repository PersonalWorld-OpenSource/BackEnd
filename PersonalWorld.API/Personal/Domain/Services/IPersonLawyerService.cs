using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Security.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Domain.Services;

public interface IPersonLawyerService
{
    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<PersonLawyer>> ListAsync();

    Task RegisterAsync(RegisterLawyerRequest request);
    //Task<PersonLawyerResponse> SaveAsync(PersonLawyer personLawyer);

    Task<PersonLawyer> FindByIdAsync(int id);

    Task UpdateAsync(int personId, UpdateLawyerRequest person);
    //Task<PersonLawyerResponse> UpdateAsync(int id, PersonLawyer personLawyer);
    Task DeleteAsync(int personId);
    //Task<PersonLawyerResponse> DeleteAsync(int id);
}