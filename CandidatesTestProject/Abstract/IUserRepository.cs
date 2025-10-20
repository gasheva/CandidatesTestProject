using CandidatesTestProject.Models;

namespace CandidatesTestProject.Abstract;

public interface IUserRepository
{
    Task<User?> FindByLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> FindByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task UpdateAsync(User user, CancellationToken cancellationToken = default);
}

