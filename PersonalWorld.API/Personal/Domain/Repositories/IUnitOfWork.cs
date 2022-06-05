namespace PersonalWorld.API.Personal.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}