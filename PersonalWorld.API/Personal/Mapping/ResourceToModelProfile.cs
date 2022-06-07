using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Personal.Services;

namespace PersonalWorld.API.Personal.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePersonLawyerResource, PersonLawyer>();
        CreateMap<SavePersonResource, Person>();
        CreateMap<SavePlanResource, Plan>();
        CreateMap<SavePersonPlanResource, PersonPlan>();
    }
}