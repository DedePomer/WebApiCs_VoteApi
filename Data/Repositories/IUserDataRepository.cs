namespace Data.Repositories;

public interface IUserDataRepository
{
    Task AddUserDataAsync(bool isService, string firstName, string surname, Guid userId);
}