namespace PersonalWorld.API.Personal.Resources;

public class SaveMessageResource
{
    public string MessageToSend { get; set; }
    
    public int ConsultId { get; set; }
    public int PersonId { get; set; }
}