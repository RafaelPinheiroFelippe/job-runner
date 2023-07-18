namespace UserManagement.Shared.Errors;

public abstract class UserManagementErrors
{
    //public const string EmailCannotBeNull = "Email cannot be null.";
    
    public static string PropertyCannotBeNull(string property) => $"Property {property} cannot be null.";
    public static string EmailIsInvalid(string email) => $"Email {email} is invalid.";
    public static string NameExceedsMaxLength(string name, int maxLength) => $"Name {name} exceeds the max length of {maxLength}.";
}