using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Repositories;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Security.Authorization.Handlers.Interfaces;
using PersonalWorld.API.Security.Domain.Services.Communication;
using PersonalWorld.API.Security.Exceptions;

namespace PersonalWorld.API.Personal.Services;
using BCryptNet = BCrypt.Net.BCrypt;
public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtHandler _jwtHandler;

    public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
    {
        _personRepository = personRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }
    
    private Person GetById(int id)
    {
        var person = _personRepository.FindById(id);
        if (person == null) throw new KeyNotFoundException("Person not found.");
        return person;
    }


    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var person = await _personRepository.FindByEmailAsync(request.Email);

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

    public async Task<IEnumerable<Person>> ListAsync()
    {
        return await _personRepository.ListAsync();
    }

    public async Task RegisterAsync(RegisterPersonRequest request)
    {
        // Validate 
        if (_personRepository.ValidateEmail(request.Email))
            throw new AppException($"Email '{request.Email}' is already taken");

        // Map Request to Person Entity
        var person = _mapper.Map<Person>(request);

        // Hash Password
        person.Password = BCryptNet.HashPassword(request.Password);

        // Save User
        try
        {
            await _personRepository.AddAsync(person);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the person: {e.Message}");
        }
    }

    /*
    public async Task<PersonResponse> SaveAsync(Person person)
    {
        try
        {
            await _personRepository.AddAsync(person);
            await _unitOfWork.CompleteAsync();

            return new PersonResponse(person);
        }
        catch (Exception e)
        {
            return new PersonResponse("An error occurred while saving an Person");
        }
    }
    */

    public async Task<Person> FindByIdAsync(int id)
    {
        return await _personRepository.FindByIdAsync(id);
    }

    public async Task UpdateAsync(int personId, UpdatePersonRequest person)
    {
        var existingPerson = GetById(personId);

        if (!string.IsNullOrEmpty(person.Password))
            existingPerson.Password = BCryptNet.HashPassword(person.Password);

        _mapper.Map(person, existingPerson);

        try
        {
            _personRepository.Update(existingPerson);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int personId)
    {
        var person = GetById(personId);

        try
        {
            _personRepository.Remove(person);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the person: {e.Message}");
        }
    }

    
}

    /*
    public async Task<PersonResponse> UpdateAsync(int id, Person person)
    {
        var existingPerson = await _personRepository.FindByIdAsync(id);
        
        if (existingPerson == null)
            return new PersonResponse("Invalid Person Id");
        
        _personRepository.Update(person);
        await _unitOfWork.CompleteAsync();

        return new PersonResponse(person);
    }

    public async Task<PersonResponse> DeleteAsync(int id)
    {
        var existingPerson = await _personRepository.FindByIdAsync(id);
        
        if (existingPerson == null)
            return new PersonResponse("Invalid Person Id");
        
        _personRepository.Remove(existingPerson);
        await _unitOfWork.CompleteAsync();

        return new PersonResponse(existingPerson);
    }
    */
