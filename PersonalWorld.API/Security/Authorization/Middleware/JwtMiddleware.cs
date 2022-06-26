using Microsoft.Extensions.Options;
using PersonalWorld.API.Personal.Domain.Services;
using PersonalWorld.API.Security.Authorization.Handlers.Interfaces;
using PersonalWorld.API.Security.Authorization.Settings;

namespace PersonalWorld.API.Security.Authorization.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IPersonService personService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var personId = handler.ValidateToken(token);
        if (personId != null)
        {
            // Attach user to context on successful JWT validation
            context.Items["Person"] = await personService.FindByIdAsync(personId.Value);
        }

        await _next(context);
    }
}