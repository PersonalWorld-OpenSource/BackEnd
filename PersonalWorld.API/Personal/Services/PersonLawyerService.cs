using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Security.Authorization.Handlers.Interfaces;
using PersonalWorld.API.Security.Domain.Services.Communication;
using PersonalWorld.API.Security.Exceptions;

namespace PersonalWorld.API.Personal.Services;
using BCryptNet = BCrypt.Net.BCrypt;

public class PersonLawyerService : IPersonLawyerService
{
    private readonly IPersonLawyerRepository _personLawyerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtHandler _jwtHandler;
    
    public PersonLawyerService(IPersonLawyerRepository personLawyerRepository, IUnitOfWork unitOfWork,IMapper mapper, IJwtHandler jwtHandler)
    {
        _personLawyerRepository = personLawyerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }
    
    private PersonLawyer GetById(int id)
    {
        var person = _personLawyerRepository.FindById(id);
        if (person == null) throw new KeyNotFoundException("Lawyer not found.");
        return person;
    }
    
    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var person = await _personLawyerRepository.FindByEmailAsync(request.Email);

        // Validate
        if (person == null || !BCryptNet.Verify(request.Password, person.Password))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username of password is incorrect");
        }

        Console.WriteLine("Authentication successful. About to generate token");

        //Authentication successful
        var response = _mapper.Map<AuthenticateResponse>(person);
        response.Token = _jwtHandler.GenerateToken(person);
        Console.WriteLine($"Generated Token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<PersonLawyer>> ListAsync()
    {
        return await _personLawyerRepository.ListAsync();
    }

    public async Task RegisterAsync(RegisterLawyerRequest request)
    {
        // Validate 
        if (_personLawyerRepository.ValidateEmail(request.Email))
            throw new AppException($"Email '{request.Email}' is already taken");

        // Map Request to Person Entity
        var person = _mapper.Map<PersonLawyer>(request);

        // Hash Password
        person.Password = BCryptNet.HashPassword(request.Password);

        // Save User
        try
        {
            await _personLawyerRepository.AddAsync(person);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the lawyer: {e.Message}");
        }
    }
/*
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
*/
    public async Task<PersonLawyer> FindByIdAsync(int id)
    {
        return await _personLawyerRepository.FindByIdAsync(id);
    }

    public async Task UpdateAsync(int personId, UpdateLawyerRequest person)
    {
        var existingPerson = GetById(personId);

        if (!string.IsNullOrEmpty(person.Password))
            existingPerson.Password = BCryptNet.HashPassword(person.Password);

        _mapper.Map(person, existingPerson);

        try
        {
            _personLawyerRepository.Update(existingPerson);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the lawyer: {e.Message}");
        }
    }

    public async Task DeleteAsync(int personId)
    {
        var person = GetById(personId);
        try
        {
            _personLawyerRepository.Remove(person);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the lawyer: {e.Message}");
        }
    }
/* 
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
    */
}