using PersonalWorld.API.Personal.Controllers;

namespace PersonalWorld.API.Personal.Domain.Models;

public class Plan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    
    //public IList<PersonPlan> PersonPlans { get; set; } = new List<PersonPlan>();
}