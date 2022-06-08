using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Resources;

public class MessageResource
{
    public int Id { get; set; }
    public string MessageToSend { get; set; }
    
    public ConsultResource Consult { get; set; }   
    public PersonResource Person { get; set; }
}