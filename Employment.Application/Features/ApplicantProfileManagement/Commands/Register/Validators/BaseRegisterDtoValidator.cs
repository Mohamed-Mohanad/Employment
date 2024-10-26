using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs;
using Employment.Domain.Entities;
using Employment.Domain.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Employment.Application.Features.Auth.Commands.Register.Validators
{
    internal class BaseRegisterDtoValidator : AbstractValidator<BaseRegisterDto>
    {
        private readonly UserManager<User> _userManager;

        public BaseRegisterDtoValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MustAsync(IsUserNameExist).WithMessage(Messages.RedundantData);

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .IsEnglish(combineNumbers: true).WithMessage(Messages.InvalidEmailAddress)
                .EmailAddress().WithMessage(Messages.InvalidEmailAddress)
                .MustAsync(IsEmailExist).WithMessage(Messages.EmailAlreadyInUse);

            RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MustAsync(IsPhoneNumExist).WithMessage(Messages.PhoneNumberAlreadyUsed);

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .IsEnglish().WithMessage(Messages.IncorrectData);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .Custom((password, context) =>
                {
                    var passwordErrors = ValidatePassword(password);
                    if (passwordErrors.Any())
                    {
                        StringBuilder errorMessage = new StringBuilder();
                        foreach (var error in passwordErrors)
                        {
                            errorMessage.AppendLine(error);
                        }
                        context.AddFailure("Password", errorMessage.ToString());
                    }
                });
        }

        private async Task<bool> IsUserNameExist(string userName, CancellationToken cancellationToken)
        {
            return !await _userManager.Users.AnyAsync(u => u.UserName == userName, cancellationToken);
        }

        private async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
        {
            return !await _userManager.Users.AnyAsync(u => u.Email == email, cancellationToken);
        }

        private async Task<bool> IsPhoneNumExist(string phoneNumber, CancellationToken cancellationToken)
        {
            return !await _userManager.Users.AnyAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);
        }

        private List<string> ValidatePassword(string password)
        {
            var errors = new List<string>();

            const int RequiredLength = 6;
            bool RequireDigit = true;
            bool RequireLowercase = true;
            bool RequireUppercase = true;
            bool RequireNonAlphanumeric = true;

            if (password.Length < RequiredLength)
            {
                errors.Add($"Password must be at least {RequiredLength} characters long.");
            }

            if (RequireDigit && !password.Any(char.IsDigit))
            {
                errors.Add("Password must contain at least one digit.");
            }

            if (RequireLowercase && !password.Any(char.IsLower))
            {
                errors.Add("Password must contain at least one lowercase letter.");
            }

            if (RequireUppercase && !password.Any(char.IsUpper))
            {
                errors.Add("Password must contain at least one uppercase letter.");
            }

            if (RequireNonAlphanumeric && !password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                errors.Add("Password must contain at least one non-alphanumeric character.");
            }

            return errors;
        }
    }
}
