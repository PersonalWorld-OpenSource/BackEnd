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
        CreateMap<Consult, ConsultResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<Message, MessageResource>();
    }
}