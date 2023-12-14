using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MailMeDtoLayer.Dtos.AppUserDtos;

namespace MailMeBusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name field cannot be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field cannot be empty");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username field cannot be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email field cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field cannot be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password repeat field cannot be empty");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Please enter maximum 20 characters");
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Please enter maximum 20 characters");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email address");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Your passwords do not match");

        }
    }
}
