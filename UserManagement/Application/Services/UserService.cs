using FluentResults;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;
using UserManagement.Domain.ValueObjects;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Application.Services;

internal class UserService
{
    private IUserRepository UserRepository { get; }

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<Result<Guid>> RegisterAsync(RegisterDto registerDto)
    {
        
        var userCreationResult = User.Create(
            registerDto.Name,
            registerDto.Email);

        if (userCreationResult.IsFailed) 
            return Result.Fail(userCreationResult.Errors);

        if (await UserRepository.IsEmailRegistered(userCreationResult.Value.Email.Value))
            return Result.Fail("Email already registered");

        await UserRepository.AddAsync(userCreationResult.Value);

        return userCreationResult.Value.Id;
    }
}