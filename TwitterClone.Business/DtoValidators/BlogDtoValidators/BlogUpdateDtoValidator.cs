using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.BlogDtos;

namespace TwitterClone.Business.DtoValidators.BlogDtoValidators
{
    public class BlogUpdateDtoValidator : AbstractValidator<BlogUpdateDto>
    {
        public BlogUpdateDtoValidator()
        {
            RuleFor(t => t.Content)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(512);
        }
    }
}
