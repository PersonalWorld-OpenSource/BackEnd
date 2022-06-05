using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Personal.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Services;

public class PersonLawyerService : IPersonLawyerService
{
    private readonly IPersonLawyerRepository _personLawyerRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public PersonLawyerService(IPersonLawyerRepository personLawyerRepository, IUnitOfWork unitOfWork)
    {
        _personLawyerRepository = personLawyerRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<PersonLawyer>> ListAsync()
    {
        return await _personLawyerRepository.ListAsync();
    }

    public async Task<PersonLawyerResponse> SaveAsync(PersonLawyer personLawyer)
    {
        try
        {
            await _personLawyerRepository.AddAsync(personLawyer);
            await _unitOfWork.CompleteAsync();
            
            return new PersonLawyerResponse(personLawyer);
        }
        catch (Exception e)
        {
            return new PersonLawyerResponse("An error occurred while saving a Lawyer");
        }
    }

    public async Task<PersonLawyer> FindByIdAsync(int id)
    {
        return await _personLawyerRepository.FindByIdAsync(id);
    }

    public async Task<PersonLawyerResponse> UpdateAsync(int id, PersonLawyer personLawyer)
    {
        var existingLawyer = await _personLawyerRepository.FindByIdAsync(id);
        if (existingLawyer == null)
            return new PersonLawyerResponse("Invalid Lawyer Id");
        
        _personLawyerRepository.Update(personLawyer);
        await _unitOfWork.CompleteAsync();

        return new PersonLawyerResponse(personLawyer);
    }

    public async Task<PersonLawyerResponse> DeleteAsync(int id)
    {
        var existingLawyer = await _personLawyerRepository.FindByIdAsync(id);
        if (existingLawyer == null)
            return new PersonLawyerResponse("Invalid Lawyer Id");
        
        _personLawyerRepository.Remove(existingLawyer);
        await _unitOfWork.CompleteAsync();

        return new PersonLawyerResponse(existingLawyer);
    }
}