using PersonalWorld.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using PersonalWorld.API.Personal.Domain.Models;

namespace PersonalWorld.API.Personal.Persistence.Contexts;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonLawyer> Lawyers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Person
        builder.Entity<Person>().ToTable("Persons");
        
        //Herencia
        builder.Entity<Person>().HasDiscriminator(p => p.Type)
            .HasValue<PersonLawyer>("lawyer");
        
        builder.Entity<Person>().HasKey(p => p.Id);
        builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Person>().Property(p => p.FisrtName).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.LastName).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Person>().Property(p => p.Password).IsRequired().HasMaxLength(40);
        builder.Entity<Person>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        builder.Entity<Person>().Property(p => p.UrlImage).IsRequired().HasMaxLength(100);
        builder.Entity<Person>().Property(p => p.Type).IsRequired().HasMaxLength(20);
        
        //Person Lawyer
        builder.Entity<PersonLawyer>().Property(l => l.Specialty).IsRequired().HasMaxLength(30);
        builder.Entity<PersonLawyer>().Property(l => l.WonCases).IsRequired();
        builder.Entity<PersonLawyer>().Property(l => l.TotalCases).IsRequired();
        builder.Entity<PersonLawyer>().Property(l => l.LostCases).IsRequired();

        //Apply Naming Conventions
        builder.UseSnakeCaseNamingConvention();
    }
}