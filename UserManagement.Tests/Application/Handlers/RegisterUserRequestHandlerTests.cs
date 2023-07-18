using FluentAssertions;
using FluentResults;
using Moq;
using UserManagement.Application.DTOs;
using UserManagement.Application.Mediator.Handlers;
using UserManagement.Application.Mediator.Requests;
using UserManagement.Application.Services;
using UserManagement.Tests.Helpers;

namespace UserManagement.Tests.Application.Handlers;

public class RegisterUserRequestHandlerTests
{
    [Fact]
    public async Task Handle_Should_Succeed()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        
        var expectedOutput = Result.Ok(Guid.NewGuid());
        userServiceMock.Setup(service => service.RegisterAsync(It.IsAny<RegisterDto>()))
            .ReturnsAsync(expectedOutput);
        
        var request = new RegisterUserRequest(new RegisterDto(TestContext.ValidEmail, TestContext.ValidName));
        var handler = new RegisterUserRequestHandler(userServiceMock.Object);
        
        // Act
        var result = await handler.Handle(request, default);
        
        // Assert
        result.IsSuccess.Should().BeTrue();
    }
    
    public static IEnumerable<object[]> InvalidRegisterDtos =>
        new List<object[]>
        {
            new object[] { new RegisterDto(TestContext.ValidEmail, TestContext.TooLongName) },
            new object[] { new RegisterDto(TestContext.ValidEmail, string.Empty) },
            new object[] { new RegisterDto(TestContext.ValidEmail, null) },
            new object[] { new RegisterDto(TestContext.InvalidEmail, TestContext.ValidName) },
            new object[] { new RegisterDto(string.Empty, TestContext.ValidName) },
            new object[] { new RegisterDto(null, TestContext.ValidName) }
        };
    
    [Theory]
    [MemberData(nameof(InvalidRegisterDtos))]
    public async Task Handle_Should_FailWhenInvalidRegisterDTO(RegisterDto registerDto)
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        
        //var expectedOutput = Result.Ok(Guid.NewGuid());
        var expectedOutput = Result.Fail(string.Empty);
        userServiceMock.Setup(service => service.RegisterAsync(It.IsAny<RegisterDto>()))
            .ReturnsAsync(expectedOutput);
        
        var request = new RegisterUserRequest(registerDto);
        var handler = new RegisterUserRequestHandler(userServiceMock.Object);
        
        // Act
        var result = await handler.Handle(request, default);
        
        // Assert
        result.IsFailure.Should().BeTrue();
    }
}