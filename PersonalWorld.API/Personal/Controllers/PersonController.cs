using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Shared.Extensions;

namespace PersonalWorld.API.Personal.Controllers;

[Route("/api/v1/[controller]")]
public class PersonController: ControllerBase
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public PersonController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PersonResource>> GetAllSync()
    {
        var persons = await _personService.ListAsync();
            
        var resources = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(persons);
            
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<PersonResource> GetPersonById(int id)
    {
        var person = await _personService.FindByIdAsync(id);
        
        var resource = _mapper.Map<Person, PersonResource>(person);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePersonResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var person = _mapper.Map<SavePersonResource, Person>(resource);

        var result = await _personService.SaveAsync(person);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var personResource = _mapper.Map<Person, PersonResource>(result.Resource);

        return Ok(personResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SavePersonResource resource, int id)
    {
        var person = _mapper.Map<SavePersonResource, Person>(resource);
        
        var result = await _personService.UpdateAsync(id, person);

        if (!result.Success)
            return BadRequest(result.Message);

        var personResource = _mapper.Map<Person, PersonResource>(result.Resource);

        return Ok(personResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _personService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var resource = _mapper.Map<Person, PersonResource>(result.Resource);
        
        return Ok(resource);
    }
}