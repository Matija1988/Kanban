using FluentValidation;

namespace Application.Handlers.Comments.Validations;

internal class CreateCommentValidation : AbstractValidator<CommentTaskCommand>
{
    public CreateCommentValidation()
    {
        RuleFor(x => x.Text).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.CreatedBy).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DateCreated).NotEmpty();
    }
}
