namespace UserManagement.Tests.Helpers;

public abstract class TestContext
{
    public const string ValidName = "validName";
    public const string ValidEmail = "valid@email.com";
    public const string InvalidEmail = "NotAnEmail";
    public const string TooLongName
        = "LongNameLongNameLongNameLongNameLongNameLongNameLongNameLongNameLongNameLongNameLongNameLongNameLongName";
}