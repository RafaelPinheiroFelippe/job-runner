using FluentResults;
using UserManagement.Shared.Errors;

namespace UserManagement.Domain.ValueObjects;

internal sealed class Name : ValueObject
{
    private const int MaxLength = 100;
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Result<Name> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Fail(UserManagementErrors.PropertyCannotBeNull(nameof(name)));
        
        if (name.Length > MaxLength)
            return Result.Fail(UserManagementErrors.NameExceedsMaxLength(name, MaxLength));

        return new Name(name);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}