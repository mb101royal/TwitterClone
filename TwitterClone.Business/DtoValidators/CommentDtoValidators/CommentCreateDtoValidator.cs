using FluentValidation;
using TwitterClone.Business.Dtos.CommentDtos;

namespace TwitterClone.Business.DtoValidators.CommentDtoValidators
{
    public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
    {
        public CommentCreateDtoValidator()
        {
            RuleFor(t => t.Message)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
            RuleFor(t => t.ParentCommentId)
                .NotEmpty();
        }
    }
}
