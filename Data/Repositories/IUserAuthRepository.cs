using Data.Model.Entity;

namespace Data.Repositories;

public interface IUserAuthRepository
{
    Task AddUsersAsync(List<UsersAuthEntity> users);
}