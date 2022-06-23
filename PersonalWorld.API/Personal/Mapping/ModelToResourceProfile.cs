using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Security.Domain.Services.Communication;


namespace PersonalWorld.API.Personal.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Person, AuthenticateResponse>();
        CreateMap<Person, PersonResource>();
        CreateMap<PersonLawyer, PersonLawyerResource>();
        CreateMap<Plan, PlanResource>();
        CreateMap<PersonPlan, PersonPlanResource>();
        CreateMap<Consult, ConsultResource>();
	    CreateMap<Notification, NotificationResource>();
        CreateMap<Message, MessageResource>();
    }
}