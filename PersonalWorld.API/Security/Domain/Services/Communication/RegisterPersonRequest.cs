using System.ComponentModel.DataAnnotations;

namespace PersonalWorld.API.Security.Domain.Services.Communication;

public class RegisterPersonRequest
{
    [Required]
    public string FisrtName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string UrlImage { get; set; }
    [Required]
    public string Type { get; set; }
}