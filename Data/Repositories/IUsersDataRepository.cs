using Data.Model.Entity;

namespace Data.Repositories;

public interface IUsersDataRepository
{
    Task AddUserDataAsync(bool isService, string firstName, string surname, Guid userId);
    Task<UsersDataEntity> GetDataByUserIdAsync(Guid userId);
}