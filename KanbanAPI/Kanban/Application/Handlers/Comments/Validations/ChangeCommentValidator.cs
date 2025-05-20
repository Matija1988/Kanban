using FluentValidation;

namespace Application.Handlers.Comments.Validations;

internal class ChangeCommentValidator : AbstractValidator<ChangeCommentCommand>
{
    public ChangeCommentValidator()
    {
        RuleFor(x => x.CommentId).NotEmpty();
        RuleFor(x => x.Tekst).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.DateModified).NotEmpty();
        RuleFor(x => x.ModifiedBy).NotEmpty().MaximumLength(50);
    }
}
