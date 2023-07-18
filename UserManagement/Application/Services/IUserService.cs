using FluentResults;
using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;

public interface IUserService
{
    Task<Result<Guid>> RegisterAsync(RegisterDto registerDto);
}