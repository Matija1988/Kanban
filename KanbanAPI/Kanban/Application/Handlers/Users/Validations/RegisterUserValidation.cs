using FluentValidation;

namespace Application.Handlers.Users.Validations;

internal sealed class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserValidation()
    {
        RuleFor(x => x.Email).EmailAddress().MaximumLength(255);
        RuleFor(x => x.Username).MaximumLength(50);
        RuleFor(x => x.Password).MaximumLength(30);
    }
}
