using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Resources;

public class ConsultResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string State { get; set; }
    
    public PersonResource Client { get; set; }
    
    public PersonResource Lawyer { get; set; }
}