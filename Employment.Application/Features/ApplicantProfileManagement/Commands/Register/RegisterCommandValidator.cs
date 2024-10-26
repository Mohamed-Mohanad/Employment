using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.Validators;
using Employment.Application.Features.Auth.Commands.Register.Abstract;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.Auth.Commands.Register
{
    internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(UserManager<User> userManager, IGenericRepository<Company> companyRepo)
        {
            RuleFor(x => x.Type)
                .IsInEnum().WithMessage(Messages.IncorrectData);

            When(x => x.Type == RegisterType.Employer, () =>
            {
                RuleFor(x => x.Employer)
                .NotNull().WithMessage(Messages.EmptyField)
                .SetValidator(new EmployerRegisterDtoValidator(userManager, companyRepo)!);
            });

            When(x => x.Type == RegisterType.Applicant, () =>
            {
                RuleFor(x => x.Applicant)
                .NotNull().WithMessage(Messages.EmptyField)
                .SetValidator(new ApplicantRegisterDtoValidator(userManager)!);
            });

        }
    }
}
