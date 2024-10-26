using Common.Application.Extensions.FluentValidation;
using Employment.Application.Features.ApplicantProfileManagement.Commands.Register.DTOs;
using Employment.Application.Features.Auth.Commands.Register.Validators;
using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Resources;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Commands.Register.Validators
{
    internal class EmployerRegisterDtoValidator : AbstractValidator<EmployerRegisterDto>
    {
        public EmployerRegisterDtoValidator(UserManager<User> userManager, IGenericRepository<Company> companyRepo)
        {
            Include(new BaseRegisterDtoValidator(userManager));

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage(Messages.EmptyField)
                .EntityExist(companyRepo);
        }
    }
}
