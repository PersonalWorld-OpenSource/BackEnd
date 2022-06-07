namespace PersonalWorld.API.Personal.Resources;

public class PersonPlanResource
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string PersonId { get; set; }
    public string PlanId { get; set; }
}