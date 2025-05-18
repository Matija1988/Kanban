using Common;

namespace Domain.Users;

public static class UserErrors
{
    public static readonly Error NotFoundByEmailOrUsername = Error.NotFound(
     "User.NotFoundByEmailOrUsername",
     "No user with provided email/username in registry!");

    public static readonly Error CredentialsEmpty = Error.NotFound(
     "User.CredentialsEmpty",
     "Identification credentials are empty!");

    public static readonly Error InvalidPasword = Error.NotFound(
        "User.InvalidPassword",
        "Invalid or empty password!");

    public static readonly Error EmailNotUnique = Error.Conflict(
       "User.EmailNotUnique",
       "User with provided email is already registered!");

    public static readonly Error UsernameNotUnique = Error.Conflict(
        "User.UsernameNotUnique",
        "Username already taken!");
}
