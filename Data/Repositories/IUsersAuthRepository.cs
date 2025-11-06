using Data.Model.Entity;

namespace Data.Repositories;

public interface IUsersAuthRepository
{
    Task<Guid> AddUserAsync(string userName, string password);
    Task<bool> IsUserExistAsync(string userName, string password);
    Task<bool> IsUserExistAsync(string username);
    Task<Guid> GetUserIdAsync(string userName);
    Task<UsersAuthEntity> GetUserByIdAsync(Guid userId);
    Task SetRefreshToken(string username, string refreshToken);
    Task<bool> TokenHashIsCorrect(string username, string refreshToken);
}