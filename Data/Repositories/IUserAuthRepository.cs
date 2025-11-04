using Data.Model.Entity;

namespace Data.Repositories;

public interface IUserAuthRepository
{
    Task AddUserAsync(string userName, string password, bool isService, string firstName, string surname);
}