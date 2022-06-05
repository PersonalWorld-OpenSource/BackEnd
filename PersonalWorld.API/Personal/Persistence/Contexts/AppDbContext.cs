using PersonalWorld.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace PersonalWorld.API.Personal.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Relationships
        
        
        
        //Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}