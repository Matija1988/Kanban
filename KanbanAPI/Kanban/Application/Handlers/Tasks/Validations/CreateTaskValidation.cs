using FluentValidation;

namespace Application.Handlers.Tasks.Validations;

internal sealed class CreateTaskValidation : AbstractValidator<CreateToDoCommand>
{
    public CreateTaskValidation()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Description).MaximumLength(2000);
        RuleFor(x => x.DateTimeStart).NotEmpty();
        RuleFor(x => x.DateTimeEnd).NotEmpty();
        RuleFor(x => x.CreatedBy).NotEmpty();
    }
}
