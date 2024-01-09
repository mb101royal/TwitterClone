using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;

namespace TwitterClone.Business.DtoValidators.AuthDtoValidators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(r => r.UsernameOrEmail)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(32);
            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(64);
        }
    }
}
