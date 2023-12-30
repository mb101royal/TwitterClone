using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;

namespace TwitterClone.Business.DtoValidators.AuthDtoValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(32);
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(26);
        }
    }
}
