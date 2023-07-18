using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using Moq;
using UserManagement.Application.DTOs;
using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;
using UserManagement.Tests.Helpers;

namespace UserManagement.Tests.Application.Services;

public class UserServiceTests
{
    private readonly UserService _userService;
    private readonly List<User> _usersDbMock;

    public UserServiceTests()
    {
        // Create a mock UserRepository
        var userRepositoryMock = new Mock<IUserRepository>();

        // Set up the repository
        _usersDbMock = new List<User>();
        
        userRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<User>()))
            .Callback<User>(_usersDbMock.Add);

        userRepositoryMock
            .Setup(r => r.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync((string email) => _usersDbMock.Any(x => x.Email.Value == email));

        _userService = new UserService(userRepositoryMock.Object);
    }

    [Fact]
    public async Task Register_Should_Succeed()
    {
        // Arrange

        // Act
        var registerResult = await _userService.RegisterAsync(new RegisterDto(TestContext.ValidEmail, TestContext.ValidName));

        // Assert
        registerResult.Should().BeSuccess();
        Assert.Single(_usersDbMock);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(TestContext.TooLongName)]
    public async Task Register_Should_Fail_WhenInvalidName(string invalidName)
    {
        // Arrange

        // Act
        var registerResult = await _userService.RegisterAsync(new RegisterDto(TestContext.ValidEmail, invalidName));

        // Assert
        registerResult.Should().BeFailure();
        _usersDbMock.Should().BeEmpty();
    }

    [Fact]
    public async Task Register_Should_Fail_WhenDuplicateEmail()
    {
        // Arrange

        // Act
        _ = await _userService.RegisterAsync(new RegisterDto(TestContext.ValidEmail, TestContext.ValidName));
        var secondRegisterResult = await _userService.RegisterAsync(new RegisterDto(TestContext.ValidEmail, TestContext.ValidName));

        // Assert
        secondRegisterResult.Should().BeFailure();
        _usersDbMock.Should().HaveCount(1);
    }
    
    [Fact]
    public async Task Register_Should_Succeed_WhenRegisteringSecondUser()
    {
        // Arrange

        // Act
        _ = await _userService.RegisterAsync(new RegisterDto(TestContext.ValidEmail, TestContext.ValidName));
        var secondRegisterResult = await _userService.RegisterAsync(new RegisterDto($"different_{TestContext.ValidEmail}", TestContext.ValidName));

        // Assert
        secondRegisterResult.Should().BeSuccess();
        _usersDbMock.Should().HaveCount(2);
    }
}