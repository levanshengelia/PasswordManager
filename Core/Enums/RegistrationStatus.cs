namespace Core.Enums
{
    public enum RegistrationStatus
    {
        Success = 1,
        PasswordsDontMatch = 2,
        InvalidEmail = 3,
        WeakPassword = 4,
        UsernameAlreadyTaken = 5,
        EmptyUsername = 6,
        ServerError = 7,
    }
}
