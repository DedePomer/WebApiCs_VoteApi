using Data.Model.Entity;

namespace Data.Repositories;

public interface IUserAuthRepository
{
    Task<Guid> AddUserAsync(string userName, string password);
}