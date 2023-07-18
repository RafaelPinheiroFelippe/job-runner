using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories;

internal interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> IsEmailRegistered(string email);
}