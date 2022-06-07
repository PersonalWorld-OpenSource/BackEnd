using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Resources;

namespace PersonalWorld.API.Personal.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePersonLawyerResource, PersonLawyer>();
        CreateMap<SavePersonResource, Person>();
        CreateMap<SavePlanResource, Plan>();
    }
}