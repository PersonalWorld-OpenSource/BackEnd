using AutoMapper;
using PersonalWorld.API.Personal.Domain.Models;
using PersonalWorld.API.Personal.Resources;
using PersonalWorld.API.Personal.Services;
using PersonalWorld.API.Security.Domain.Services.Communication;

namespace PersonalWorld.API.Personal.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SavePersonLawyerResource, PersonLawyer>();
        CreateMap<SavePersonResource, Person>();
        CreateMap<SavePlanResource, Plan>();
        CreateMap<SavePersonPlanResource, PersonPlan>();
        CreateMap<SaveConsultResource, Consult>();
	    CreateMap<SaveNotificationResource, Notification>();
        CreateMap<SaveMessageResource, Message>();
        CreateMap<RegisterPersonRequest, Person>();
        CreateMap<UpdatePersonRequest, Person>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && 
                        string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }));
    }
}