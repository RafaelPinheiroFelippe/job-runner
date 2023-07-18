using System.ComponentModel.DataAnnotations;
using FluentResults;
using UserManagement.Shared.Errors;

namespace UserManagement.Domain.ValueObjects;

internal sealed class Email : ValueObject
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Fail(UserManagementErrors.PropertyCannotBeNull(nameof(email)));
        
        if (!new EmailAddressAttribute().IsValid(email)) 
            return Result.Fail(UserManagementErrors.EmailIsInvalid(email));
        
        return new Email(email);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}