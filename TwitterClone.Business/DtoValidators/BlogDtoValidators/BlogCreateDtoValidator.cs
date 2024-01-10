using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Dtos.TopicDtos;

namespace TwitterClone.Business.DtoValidators.BlogDtoValidators
{
    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(t => t.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(512);
        }
    }
}
