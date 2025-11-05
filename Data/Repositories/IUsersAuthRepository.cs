using Data.Model.Entity;

namespace Data.Repositories;

public interface IUsersAuthRepository
{
    Task<Guid> AddUserAsync(string userName, string password);
    Task<bool> IsUserExist(string userName, string password);
    Task<Guid> GetUserId(string userName);
}