using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IPersonLawyerRepository
{
    Task<IEnumerable<PersonLawyer>> ListAsync();
    
    Task AddAsync(PersonLawyer personLawyer);
    
    Task<PersonLawyer> FindByIdAsync(int id);
    
    void Update(PersonLawyer personLawyer);
    
    void Remove(PersonLawyer personLawyer);
    
    Task<PersonLawyer> FindByEmailAsync(string email);
    public bool ValidateEmail(string email);
    public PersonLawyer FindById(int id);
}
