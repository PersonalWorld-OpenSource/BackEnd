using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Security.Domain.Services.Communication;

public class UpdatePersonRequest
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string UrlImage { get; set; }
    public string Type { get; set; }
}