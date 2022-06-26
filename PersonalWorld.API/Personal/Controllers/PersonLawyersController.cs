using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Security.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]

public class PersonLawyersController : ControllerBase
{
    private readonly IPersonLawyerService _personLawyerService;
    private readonly IMapper _mapper;

    public PersonLawyersController(IPersonLawyerService personLawyerService, IMapper mapper)
    {
        _personLawyerService = personLawyerService;
        _mapper = mapper;
    }
    /*
    [AllowAnonymous]
    [HttpPost("/auth/sign-inL")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _personLawyerService.Authenticate(request);
        return Ok(response);
    }
    */

    [AllowAnonymous]
    [HttpPost("/auth/sign-upL")]
    public async Task<IActionResult> Register(RegisterLawyerRequest request)
    {
        await _personLawyerService.RegisterAsync(request);
        return Ok(new {message = "Registration successful."});
    }

    [HttpGet("{id}")]
    public async Task<PersonLawyerResource> GetLawyerById(int id)
    {
        var person = await _personLawyerService.FindByIdAsync(id);
        
        var resource = _mapper.Map<Person, PersonLawyerResource>(person);
        
        return resource;
    }

    [HttpGet]
    public async Task<IEnumerable<PersonLawyerResource>> GetAllAsync()
    {
        var lawyers = await _personLawyerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<PersonLawyer>, IEnumerable<PersonLawyerResource>>(lawyers);
        return resources;
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLawyerRequest request)
    {
        await _personLawyerService.UpdateAsync(id, request);
        return Ok(new {message = "Lawyer Updated Successfully."});
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _personLawyerService.DeleteAsync(id);
        return Ok(new {message = "Lawyer Deleted successfully."});
    }

    /*
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePersonLawyerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        //Mapear el objeto a una entidad
        var lawyer = _mapper.Map<SavePersonLawyerResource, PersonLawyer>(resource);
        var result = await _personLawyerService.SaveAsync(lawyer);

        if (!result.Success)
            return BadRequest(result.Message);

        var lawyerResource = _mapper.Map<PersonLawyer, PersonLawyerResource>(result.Resource);
        return Ok(lawyerResource);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] SavePersonLawyerResource resource, int id)
    {
        var lawyer = _mapper.Map<SavePersonLawyerResource, PersonLawyer>(resource);
        var result = await _personLawyerService.UpdateAsync(id, lawyer);

        if (!result.Success)
            return BadRequest(result.Message);

        var lawyerResource = _mapper.Map<PersonLawyer, PersonLawyerResource>(result.Resource);

        return Ok(lawyerResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _personLawyerService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        var lawyerResource = _mapper.Map<PersonLawyer, PersonLawyerResource>(result.Resource);
        
        return Ok(lawyerResource);
    }
    */
}