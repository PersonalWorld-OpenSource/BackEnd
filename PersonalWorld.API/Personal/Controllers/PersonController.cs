using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalWorld.API.Personal.Domain.Services;


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
    
    
    
}