using Costium.Domain.Entities;

namespace Costium.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByLoginAsync(string login);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
}
