using FluentResults.Extensions.FluentAssertions;
using UserManagement.Domain.Entities;
using UserManagement.Tests.Helpers;

namespace UserManagement.Tests.Domain.Entities;

public class UserTests
{   
    [Fact]
    public void Create_Should_Succeed()
    {
        // Arrange
        
        // Act
        var userCreationResult = User.Create(TestContext.ValidName, TestContext.ValidEmail);
        
        // Assert
        userCreationResult.Should().BeSuccess();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(TestContext.TooLongName)]
    public void Create_Should_Fail_WhenInvalidName(string invalidName)
    {
        // Arrange
        
        // Act
        var userCreationResult = User.Create(invalidName, TestContext.ValidEmail);
        
        // Assert
        userCreationResult.Should().BeFailure();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(TestContext.InvalidEmail)]
    public void Create_Should_Fail_WhenInvalidEmail(string invalidEmail)
    {
        // Arrange
        
        // Act
        var userCreationResult = User.Create(TestContext.ValidName, invalidEmail);
        
        // Assert
        userCreationResult.Should().BeFailure();
    }
}