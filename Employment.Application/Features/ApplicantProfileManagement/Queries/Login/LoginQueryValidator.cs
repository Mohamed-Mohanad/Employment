using Employment.Domain.Entities;
using Employment.Domain.Resources;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login
{
    internal class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        private readonly UserManager<User> _userManager;
        private User? _user;
        public LoginQueryValidator(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .EmailAddress().WithMessage(Messages.InvalidEmailAddress)
                .MustAsync(UserExistAsync).WithMessage(Messages.IncorrectEmailOrPassword);


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .MustAsync(PasswordCorrectAsync).WithMessage(Messages.IncorrectEmailOrPassword);

        }

        private async Task<bool> UserExistAsync(string email, CancellationToken cancellationToken)
        {
            await GetUser(email);
            return _user != null;
        }

        private async Task<bool> PasswordCorrectAsync(string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CheckPasswordAsync(_user!, password);
            return result == true;
        }

        private async Task GetUser(string email)
        {
            if (_user is null)
                _user = await _userManager.FindByEmailAsync(email);
        }
    }
}
