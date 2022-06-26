using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(Person person);
    int? ValidateToken(string token);
}