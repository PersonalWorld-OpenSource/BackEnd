using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Resources;


namespace PersonalWorld.API.Personal.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Person, PersonResource>();
        CreateMap<PersonLawyer, PersonLawyerResource>();
        CreateMap<Plan, PlanResource>();
        CreateMap<PersonPlan, PersonPlanResource>();
        CreateMap<Consult, ConsultResource>();
    }
}