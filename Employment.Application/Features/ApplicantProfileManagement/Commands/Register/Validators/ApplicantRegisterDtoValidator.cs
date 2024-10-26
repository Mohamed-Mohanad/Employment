using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs;
using Employment.Application.Features.Auth.Commands.Register.Validators;
using Employment.Domain.Entities;
using Employment.Domain.Resources;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Commands.Register.Validators
{
    internal class ApplicantRegisterDtoValidator : AbstractValidator<ApplicantRegisterDto>
    {
        public ApplicantRegisterDtoValidator(UserManager<User> userManager)
        {
            Include(new BaseRegisterDtoValidator(userManager));

            RuleFor(x => x.ResumeUrl)
            .NotEmpty().WithMessage(Messages.EmptyField)
            .Must(BeAValidUrl).WithMessage(Messages.InvalidUrl);

        }
        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
