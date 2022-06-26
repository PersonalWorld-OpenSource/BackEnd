using System.ComponentModel.DataAnnotations;

namespace PersonalWorld.API.Security.Domain.Services.Communication;

public class RegisterLawyerRequest
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
    [Required]
    public string Specialty { get; set; }
    [Required]
    public int WonCases { get; set; }
    [Required]
    public int TotalCases { get; set; }
    [Required]
    public int LostCases { get; set; }
}