using FluentResults;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Entities;

internal class User
{
    public Guid Id { get; }
    public Name Name { get; }
    public Email Email { get; }

    public static Result<User> Create(string name, string email)
    {
        var nameResult = Name.Create(name);
        var emailResult = Email.Create(email);
        
        var userCreationArgumentsResult = Result.Merge(nameResult, emailResult);
        if (userCreationArgumentsResult.IsFailed) 
            return Result.Fail(userCreationArgumentsResult.Errors);
        
        return new User(nameResult.Value, emailResult.Value);
    }

    private User(Name name, Email email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }
}